using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using Microsoft.IdentityModel.Tokens;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public delegate List<TEntidade> SelecionarTodosDelegate<TEntidade>()
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate List<TEntidade> SelecionarPorFiltroListaDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate TEntidade SelecionarPorFiltroDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate Decimal CalcularValorTotalDelegate<TEntidadde>(TEntidadde entidade);

    public partial class TelaAluguelForm : Form
    {
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

        // Calcular Valor Total

        public event CalcularValorTotalDelegate<Aluguel> onCalcularValorTotal;


        Aluguel aluguel;

        private bool ehDevolucao;

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            tctrlTaxas.TabPages.Remove(tbTaxasAdicionais);

            //tctrlTaxas.TabPages.Add(tbTaxasAdicionais);

            txtDataLocacao.MinDate = DateTime.Now;
            txtDevolucaoPrevista.MinDate = DateTime.Now.AddDays(1);
        }

        public void ConfigurarRegistro(Aluguel aluguelSelecionado)
        {
            this.aluguel = aluguelSelecionado;

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

            cbxGrupoAutomovel.SelectedItem = aluguelSelecionado.GrupoAutomovel;

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
            }

            PreencherTaxas(aluguelSelecionado);

            cbxNivelTanque.DataSource = Enum.GetValues<NivelCombustivelEnum>();
        }

        public void ConfigurarDevolucao(Aluguel aluguelSelecionado)
        {
            ConfigurarRegistro(aluguelSelecionado);

            gbLocacao.Enabled = false;

            gbDevolucao.Enabled = true;

            ehDevolucao = true;

            clbxTaxasSelecionadas.Enabled = false;

            tctrlTaxas.TabPages.Add(tbTaxasAdicionais);



        }
        private void PreencherTaxas(Aluguel aluguel, bool adicionais = false)
        {
            List<TaxaServico> listaTaxasServicos = onSelecionarTodosTaxaServico();
            foreach (TaxaServico taxaServico in listaTaxasServicos)
            {
                if (aluguel.TaxasServicos.Contains(taxaServico) && adicionais == false)
                {
                    clbxTaxasSelecionadas.Items.Add(taxaServico, true);
                }
                else if (!aluguel.TaxasServicos.Contains(taxaServico) && adicionais)
                {
                    clbxTaxasAdicionais.Items.Add(taxaServico, false);
                }
                else
                {
                    clbxTaxasSelecionadas.Items.Add(taxaServico, false);
                }
            }
        }

        private void SalvarTaxasSelecionadas()
        {
            aluguel.TaxasServicos.Clear();

            foreach (TaxaServico taxaServico in clbxTaxasSelecionadas.CheckedItems)
            {
                aluguel.TaxasServicos.Add(taxaServico);
            }
        }
        private void cbxCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxCondutor.DataSource = onSelecionarCondutorPorCliente(cbxCliente.SelectedItem as Cliente);
            cbxCondutor.Enabled = true;
        }

        private void cbxGrupoAutomovel_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxAutomovel.DataSource = onSelecionarAutomovelPorGrupoAutomovel(cbxGrupoAutomovel.SelectedItem as GrupoAutomovel);
            cbxAutomovel.Enabled = true;

            cbxPlanoDeCobranca.DataSource = onSelecionarTodosPlanoDeCobrancaPorGrupoAutomovel(cbxGrupoAutomovel.SelectedItem as GrupoAutomovel);
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

        private void btnCupom_Click(object sender, EventArgs e)
        {
            if (btnCupom.Text == "Remover Cupom")
            {
                aluguel.Cupom = null;
                txtCupom.Enabled = true;
                btnCupom.Text = "Aplicar Cupom";
            }
            else if (String.IsNullOrEmpty(txtCupom.Text) == false)
            {
                txtCupom.Text = txtCupom.Text.ToUpper();
                Cupom cupom = onSelecionarCupomPorNome(txtCupom.Text);
                if (cupom != null && cupom.EhValido)
                {
                    aluguel.Cupom = cupom;
                    txtCupom.Enabled = false;
                    btnCupom.Text = "Remover Cupom";
                }
                if(cupom == null || cupom.EhValido == false)
                {
                    MessageBox.Show($"Cupom inválido",
                                 "Cupom inválido",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                }
            }
            AtualizarValorTotal();
        }

        private void AtualizarValorTotal_event(object sender, EventArgs e)
        {
            if (aluguel != null)
            {
                aluguel.PlanoDeCobranca = cbxPlanoDeCobranca.SelectedItem as PlanoDeCobranca;
                aluguel.DataLocacao = txtDataLocacao.Value;
                aluguel.DataDevolucaoPrevista = txtDevolucaoPrevista.Value;
                AtualizarValorTotal();
            }
        }

        private void AtualizarValorTotal()
        {
            Decimal valorTotal;

            valorTotal = onCalcularValorTotal(aluguel);
            if (ehDevolucao)
            {
                aluguel.DataDevolucao = txtDataDevolucao.Value;
                aluguel.NivelCombustivelAtual = (NivelCombustivelEnum)cbxNivelTanque.SelectedItem;
            }

            txtValorTotal.Text = "R$" + valorTotal.ToString();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            aluguel.Funcionario = cbxFuncionario.SelectedItem as Funcionario;
            aluguel.Cliente = cbxCliente.SelectedItem as Cliente;
            aluguel.Condutor = cbxCondutor.SelectedItem as Condutor;
            aluguel.GrupoAutomovel = cbxGrupoAutomovel.SelectedItem as GrupoAutomovel;
            aluguel.Automovel = cbxAutomovel.SelectedItem as Automovel;
            aluguel.PlanoDeCobranca = cbxPlanoDeCobranca.SelectedItem as PlanoDeCobranca;
            if (String.IsNullOrEmpty(txtQuilometragem.Text) == null)
            {
                aluguel.KMPercorrido = Convert.ToInt32(txtQuilometragem.Text);
            }
            else
            {
                aluguel.KMPercorrido = 0;
            }
            aluguel.DataLocacao = txtDataLocacao.Value;
            aluguel.DataDevolucaoPrevista = txtDevolucaoPrevista.Value;

            if (ehDevolucao)
            {
                aluguel.ValorTotal = onCalcularValorTotal(aluguel);
                aluguel.NivelCombustivelAtual = (NivelCombustivelEnum)cbxNivelTanque.SelectedItem;
                aluguel.KMPercorrido = Convert.ToInt32(txtQuilometragem.Text);
            }
            else
            {
                aluguel.ValorTotalPrevisto = onCalcularValorTotal(aluguel);
            }

            Result resultado = onGravarRegistro(aluguel);


            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void clbxTaxasSelecionadas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            TaxaServico taxaServico = clbxTaxasSelecionadas.Items[e.Index] as TaxaServico;
            if (e.NewValue == CheckState.Checked)
            {
                aluguel.TaxasServicos.Add(taxaServico);
            }
            else
            {
                aluguel.TaxasServicos.Remove(taxaServico);
            }
            AtualizarValorTotal();
        }

        private void clbxTaxasAdicionais_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            TaxaServico taxaServico = clbxTaxasAdicionais.Items[e.Index] as TaxaServico;
            if (e.NewValue == CheckState.Checked)
            {
                aluguel.TaxasServicos.Add(taxaServico);
            }
            else
            {
                aluguel.TaxasServicos.Remove(taxaServico);
            }
            AtualizarValorTotal();
        }

        private void txtDataLocacao_ValueChanged(object sender, EventArgs e)
        {
            if (txtDevolucaoPrevista.Value < txtDataLocacao.Value)
            {
                txtDevolucaoPrevista.Value = txtDataLocacao.Value.AddDays(1); 
            }
            txtDevolucaoPrevista.MinDate = txtDataLocacao.Value.AddDays(1);
            if (aluguel != null)
            {
                aluguel.DataLocacao = txtDataLocacao.Value;
                AtualizarValorTotal();
            }
        }
    }
}
