namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia { get; private set; } = null!;

        private ControladorBase controlador = null!;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Ioc.Inicializar = true;

            Instancia = this;
        }

        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        private void ConfigurarToolsTips(ConfiguracaoToolboxBase configuracao)
        {
            BtnInserir.ToolTipText = configuracao.TooltipInserir;
            BtnEditar.ToolTipText = configuracao.TooltipEditar;
            BtnExcluir.ToolTipText = configuracao.TooltipExcluir;
            BtnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            BtnInserir.Enabled = configuracao.InserirHabilitado;
            BtnEditar.Enabled = configuracao.EditarHabilitado;
            BtnExcluir.Enabled = configuracao.ExcluirHabilitado;
            BtnFiltrar.Enabled = configuracao.FiltrarHabilitado;
        }

        public void AtualizarRodape(string msg)
        {

        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void BtnGerarPdf_Click(object sender, EventArgs e)
        {

        }
    }
}