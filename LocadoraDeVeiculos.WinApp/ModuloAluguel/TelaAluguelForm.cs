using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.IdentityModel.Tokens;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public delegate List<TEntidade> SelecionarTodosDelegate<TEntidade>()
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate List<TEntidade> SelecionarPorFiltroListaDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate TEntidade SelecionarPorFiltroDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;

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

        Aluguel aluguel;

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            tctrlTaxas.TabPages.Remove(tbTaxasAdicionais);

            //tctrlTaxas.TabPages.Add(tbTaxasAdicionais);
        }

        public void ConfigurarRegistro(Aluguel aluguelSelecionado)
        {
            this.aluguel = aluguelSelecionado;

            cbxFuncionario.DataSource = onSelecionarTodosFuncionarios();

            cbxFuncionario.SelectedItem = aluguelSelecionado.Funcionario;

            cbxCliente.DataSource = onSelecionarTodosClientes();

            cbxCliente.SelectedItem = aluguelSelecionado.Cliente;

            cbxCondutor.DataSource = onSelecionarCondutorPorCliente(aluguelSelecionado.Cliente);

            cbxCondutor.SelectedItem = aluguelSelecionado.Condutor;

            cbxGrupoAutomovel.DataSource = onSelecionarTodosGrupoAutomovel();

            cbxGrupoAutomovel.SelectedItem = aluguelSelecionado.GrupoAutomovel;

            cbxAutomovel.DataSource = onSelecionarAutomovelPorGrupoAutomovel(aluguelSelecionado.GrupoAutomovel);

            cbxAutomovel.SelectedItem = aluguelSelecionado.Automovel;

            cbxPlanoDeCobranca.DataSource = onSelecionarTodosPlanoDeCobrancaPorGrupoAutomovel(aluguelSelecionado.GrupoAutomovel);

            cbxPlanoDeCobranca.SelectedItem = aluguelSelecionado.PlanoDeCobranca;

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
            cbxNivelTanque.DataSource = Enum.GetValues<NivelCombustivelEnum>();
        }

        public void ConfigurarDevolucao(Aluguel aluguelSelecionado)
        {
            ConfigurarRegistro(aluguelSelecionado);

            gbLocacao.Enabled = false;

            gbDevolucao.Enabled = true;



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
                Cupom cupom = onSelecionarCupomPorNome(txtCupom.Text);
                if (cupom != null)
                {
                    aluguel.Cupom = cupom;
                    txtCupom.Enabled = false;
                    btnCupom.Text = "Remover Cupom";
                }
            }
        }
    }
}
