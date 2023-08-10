using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    #region Delegates
    public delegate List<TEntidade> SelecionarTodosDelegate<TEntidade>()
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate List<TEntidade> SelecionarPorFiltroListaDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate TEntidade SelecionarPorFiltroDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;


    public delegate Decimal CalcularValorTotalDelegate(DateTime dataLocacao,
                                                         DateTime dataDevolucaoPrevista,
                                                         DateTime dataDevolucao,
                                                         NivelCombustivelEnum nivelCombustivelAtual,
                                                         HashSet<TaxaServico> taxasServicos = null,
                                                         PlanoDeCobranca planoDeCobranca = null,
                                                         Automovel automovel = null,
                                                         int KMPercorrido = 1,
                                                         Cupom cupom = null,
                                                         bool ehDevolucao = false
                                                        );
    #endregion Delegates
    public partial class TelaAluguelForm : Form
    {

        #region Propiedades
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

        // Funcionario

        public event SelecionarTodosDelegate<Funcionario> onSelecionarTodosFuncionarios;

        // Cliente e Condutor

        public event SelecionarTodosDelegate<Cliente> onSelecionarTodosClientes;

        public event SelecionarPorFiltroListaDelegate<Condutor, Cliente> onSelecionarCondutorPorCliente;

        // Grupo de Automoveis e Automovel

        public event SelecionarTodosDelegate<GrupoAutomovel> onSelecionarTodosGrupoAutomovel;

        public event SelecionarPorFiltroListaDelegate<Automovel, GrupoAutomovel> onSelecionarAutomovelPorGrupoAutomovel;


        // Plano de Cobranca

        public event SelecionarPorFiltroListaDelegate<PlanoDeCobranca, GrupoAutomovel> onSelecionarTodosPlanoDeCobrancaPorGrupoAutomovel;

        // Cupom 

        public event SelecionarPorFiltroDelegate<Cupom, string> onSelecionarCupomPorNome;

        // Taxas ou Servicos

        public event SelecionarTodosDelegate<TaxaServico> onSelecionarTodosTaxaServico;

        // Calcular Valor

        public event CalcularValorTotalDelegate onCalcularValorTotal;


        private Aluguel aluguel;

        private HashSet<TaxaServico> taxasServicos;

        private Cupom cupom;

        private bool ehDevolucao;


        #endregion Propiedades

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            tctrlTaxas.TabPages.Remove(tbTaxasAdicionais);

            this.taxasServicos = new();

        }
        #region ConfigurarRegistro
        public void ConfigurarRegistro(Aluguel aluguelSelecionado)
        {
            this.aluguel = aluguelSelecionado;

            if (aluguel.TaxasServicos.Count > 0)
            {
                this.taxasServicos.UnionWith(aluguel.TaxasServicos);
            }

            cbxFuncionario.DataSource = onSelecionarTodosFuncionarios();

            cbxFuncionario.SelectedItem = aluguelSelecionado.Funcionario;

            cbxCliente.DataSource = onSelecionarTodosClientes();

            cbxCliente.SelectedItem = aluguelSelecionado.Cliente;

            cbxCondutor.DataSource = onSelecionarCondutorPorCliente(aluguelSelecionado.Cliente);

            if (aluguelSelecionado.Condutor != null)
            {
                cbxCondutor.SelectedItem = aluguelSelecionado.Condutor;
            }
            else
            {
                cbxCondutor.Enabled = false;
            }

            cbxGrupoAutomovel.DataSource = onSelecionarTodosGrupoAutomovel();

            cbxAutomovel.DataSource = onSelecionarAutomovelPorGrupoAutomovel(aluguelSelecionado.GrupoAutomovel);


            if (aluguelSelecionado.Automovel != null)
            {
                cbxAutomovel.SelectedItem = aluguelSelecionado.Automovel;
            }
            else
            {
                cbxAutomovel.Enabled = false;
            }

            cbxPlanoDeCobranca.DataSource = onSelecionarTodosPlanoDeCobrancaPorGrupoAutomovel(aluguelSelecionado.GrupoAutomovel);

            if (aluguelSelecionado.PlanoDeCobranca != null)
            {
                cbxPlanoDeCobranca.SelectedItem = aluguelSelecionado.PlanoDeCobranca;
            }
            else
            {
                cbxPlanoDeCobranca.Enabled = false;
            }

            txtQuilometragem.Text = aluguelSelecionado.KMPercorrido.ToString();

            if (aluguelSelecionado.DataLocacao != default(DateTime))
            {
                txtDataLocacao.Value = aluguelSelecionado.DataLocacao;
            }

            if (aluguelSelecionado.DataDevolucaoPrevista != default(DateTime))
            {
                txtDevolucaoPrevista.Value = aluguelSelecionado.DataDevolucaoPrevista;
            }

            if (aluguel.Cupom != null)
            {
                txtCupom.Text = aluguel.Cupom.Nome;

                txtCupom.Enabled = false;

                btnCupom.Text = "Remover Cupom";

                cupom = aluguel.Cupom;
            }

            PreencherTaxas(aluguelSelecionado);

            cbxNivelTanque.DataSource = Enum.GetValues<NivelCombustivelEnum>();

            cbxNivelTanque.SelectedItem = NivelCombustivelEnum.Cheio;
        }
        public void ConfigurarDevolucao(Aluguel aluguelSelecionado)
        {
            ConfigurarRegistro(aluguelSelecionado);

            if (DateTime.Now.AddDays(-7) > aluguel.DataLocacao)
            {
                txtDataDevolucao.MinDate = DateTime.Now.AddDays(-7);
            }
            else
            {
                txtDataDevolucao.MinDate = aluguel.DataLocacao;
            }
            txtDataDevolucao.Value = DateTime.Now;
            txtDataDevolucao.MaxDate = DateTime.Now;

            gbLocacao.Enabled = false;

            gbDevolucao.Enabled = true;

            PreencherTaxas(aluguelSelecionado, true);

            tctrlTaxas.SelectedIndex = 1;

            ehDevolucao = true;

            clbxTaxasSelecionadas.Enabled = false;

            tctrlTaxas.TabPages.Add(tbTaxasAdicionais);

            AtualizarValorTotal();

        }

        #endregion ConfigurarRegistro

        #region Taxas
        private void PreencherTaxas(Aluguel aluguel, bool adicionais = false)
        {
            List<TaxaServico> listaTaxasServicos = onSelecionarTodosTaxaServico();
            foreach (TaxaServico taxaServico in listaTaxasServicos)
            {
                if (taxasServicos.Contains(taxaServico) && adicionais == false)
                {
                    clbxTaxasSelecionadas.Items.Add(taxaServico, true);
                }
                else if (!taxasServicos.Contains(taxaServico) && adicionais)
                {
                    clbxTaxasAdicionais.Items.Add(taxaServico, false);
                }
                else
                {
                    clbxTaxasSelecionadas.Items.Add(taxaServico, false);
                }
            }
        }

        private void clbxTaxasSelecionadas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            TaxaServico taxaServico = clbxTaxasSelecionadas.Items[e.Index] as TaxaServico;

            if (e.NewValue == CheckState.Checked && !taxasServicos.Contains(taxaServico))
            {
                taxasServicos.Add(taxaServico);
            }
            else if (e.NewValue == CheckState.Unchecked && taxasServicos.Contains(taxaServico))
            {
                taxasServicos.Remove(taxaServico);
            }
            AtualizarValorTotal();
        }
        private void clbxTaxasAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            TaxaServico taxaServico = clbxTaxasAdicionais.Items[e.Index] as TaxaServico;
            if (e.NewValue == CheckState.Checked && !taxasServicos.Contains(taxaServico))
            {
                taxasServicos.Add(taxaServico);
            }
            else if (e.NewValue == CheckState.Unchecked && taxasServicos.Contains(taxaServico))
            {
                taxasServicos.Remove(taxaServico);
            }
            AtualizarValorTotal();
        }

        #endregion Taxas

        #region Eventos
        private void cbxCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxCondutor.DataSource = onSelecionarCondutorPorCliente((Cliente)cbxCliente.SelectedItem);
            cbxCondutor.Enabled = true;
        }

        private void cbxGrupoAutomovel_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxAutomovel.DataSource = onSelecionarAutomovelPorGrupoAutomovel((GrupoAutomovel)cbxGrupoAutomovel.SelectedItem);
            cbxAutomovel.Enabled = true;

            cbxPlanoDeCobranca.DataSource = onSelecionarTodosPlanoDeCobrancaPorGrupoAutomovel((GrupoAutomovel)cbxGrupoAutomovel.SelectedItem);
            cbxPlanoDeCobranca.Enabled = true;
        }

        private void cbxAutomovel_SelectedValueChanged(object sender, EventArgs e)
        {
            Automovel automovel = cbxAutomovel.SelectedItem as Automovel;
            if (automovel != null)
            {
                txtQuilometragem.Text = automovel.Quilometragem.ToString();
            }
        }
        private void AtualizarValorTotal_event(object sender, EventArgs e)
        {
            AtualizarValorTotal();
        }
        private void txtDataLocacao_ValueChanged(object sender, EventArgs e)
        {
            txtDevolucaoPrevista.Enabled = true;
            if (txtDevolucaoPrevista.Value < txtDataLocacao.Value)
            {
                txtDevolucaoPrevista.Value = txtDataLocacao.Value.AddDays(1);
            }
            txtDevolucaoPrevista.MinDate = txtDataLocacao.Value.AddDays(1);

            AtualizarValorTotal();
        }

        #endregion Eventos

        #region Cupom
        private void btnCupom_Click(object sender, EventArgs e)
        {
            if (btnCupom.Text == "Remover Cupom")
            {
                this.cupom = null;
                txtCupom.Enabled = true;
                btnCupom.Text = "Aplicar Cupom";
            }
            else if (String.IsNullOrEmpty(txtCupom.Text) == false)
            {
                txtCupom.Text = txtCupom.Text.ToUpper();

                Cupom cupomTemp = onSelecionarCupomPorNome(txtCupom.Text);

                Cliente clienteTemp = (Cliente)cbxCliente.SelectedItem;

                if (cupomTemp != null && cupomTemp.EhValido && !clienteTemp.ListaCupons.Contains(cupomTemp))
                {
                    this.cupom = cupomTemp;

                    txtCupom.Enabled = false;

                    btnCupom.Text = "Remover Cupom";

                }
                else
                {
                    MessageBox.Show($"Cupom inválido",
                                 "Cupom inválido",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                }
            }
            AtualizarValorTotal();
        }
        #endregion Cupom

        #region Calcular Valor
        private void AtualizarValorTotal()
        {
            Decimal valorTotal;

            NivelCombustivelEnum nivelCombustivel;

            if (cbxNivelTanque.SelectedValue == null)
            {
                nivelCombustivel = NivelCombustivelEnum.Cheio;
            }
            else
            {
                nivelCombustivel = (NivelCombustivelEnum)cbxNivelTanque.SelectedValue;
            }

            PlanoDeCobranca? planoDeCobranca = cbxPlanoDeCobranca.SelectedItem as PlanoDeCobranca;

            Automovel? automovel = cbxAutomovel.SelectedItem as Automovel;

            valorTotal = onCalcularValorTotal(txtDataLocacao.Value,
                                            txtDevolucaoPrevista.Value,
                                            txtDataDevolucao.Value,
                                            nivelCombustivel,
                                            this.taxasServicos,
                                            planoDeCobranca,
                                            automovel,
                                            Convert.ToInt32(txtKMPercorrido.Value),
                                            this.cupom,
                                            ehDevolucao);

            txtValorTotal.Text = "R$" + valorTotal.ToString();
        }
        #endregion Calcular Valor
        #region Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            aluguel.Funcionario = (Funcionario)cbxFuncionario.SelectedItem;
            aluguel.Cliente = (Cliente)cbxCliente.SelectedItem;
            aluguel.Condutor = (Condutor)cbxCondutor.SelectedItem;
            aluguel.GrupoAutomovel = (GrupoAutomovel)cbxGrupoAutomovel.SelectedItem;
            aluguel.Automovel = (Automovel)cbxAutomovel.SelectedItem;
            aluguel.PlanoDeCobranca = (PlanoDeCobranca)cbxPlanoDeCobranca.SelectedItem;
            aluguel.DataLocacao = txtDataLocacao.Value;
            aluguel.DataDevolucaoPrevista = txtDevolucaoPrevista.Value;

            aluguel.TaxasServicos.UnionWith(taxasServicos);

            if (cupom == null)
            {
                aluguel.Cupom = null;
            }

            aluguel.Cupom = cupom;


            if (ehDevolucao)
            {
                aluguel.EstaAberto = false;
                aluguel.NivelCombustivelAtual = (NivelCombustivelEnum)cbxNivelTanque.SelectedItem;
                aluguel.KMPercorrido = Convert.ToInt32(txtKMPercorrido.Text);
                aluguel.DataDevolucao = txtDataDevolucao.Value;
            }

            Result resultado = onGravarRegistro(aluguel);


            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
        #endregion Salvar

    }
}
