using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public delegate List<TEntidade> SelecionarTodosDelegate<TEntidade>()
        where TEntidade : EntidadeBase<TEntidade>;

    public delegate List<TEntidade> SelecionarPorFiltroDelegate<TEntidade, TEntidadeFiltro>(TEntidadeFiltro filtro)
        where TEntidade : EntidadeBase<TEntidade>;



    public partial class TelaAluguelForm : Form
    {
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

        // Funcionario

        public event SelecionarTodosDelegate<Funcionario> onSelecionarTodosFuncionarios;

        // Cliente e Condutor

        public event SelecionarTodosDelegate<Cliente> onSelecionarTodosClientes;

        public event SelecionarPorFiltroDelegate<Condutor, Cliente> onSelecionarCondutorPorCliente;

        // Grupo de Automoveis e Automovel

        public event SelecionarTodosDelegate<GrupoAutomovel> onSelecionarTodosGrupoAutomovel;

        public event SelecionarPorFiltroDelegate<Automovel, GrupoAutomovel> onSelecionarAutomovelPorGrupoAutomovel;

        // Plano de Cobranca

        public event SelecionarTodosDelegate<PlanoDeCobranca> onSelecionarTodosPlanoDeCobranca;

        // Cupom 

        public event SelecionarPorFiltroDelegate<Cupom, string> onnSelecionarCupomPorNome;

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

            //cbxPlanoDeCobranca.DataSource = onSelecionarTodosPlanoDeCobranca();

            cbxPlanoDeCobranca.SelectedItem = aluguelSelecionado.PlanoDeCobranca;

            txtQuilometragem.Text = aluguelSelecionado.KmAutomovelAtual.ToString();

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
    }
}
