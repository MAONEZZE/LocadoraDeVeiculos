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

        private void ConfigurarToolsTips(ControladorBase controlador)
        {
            BtnInserir.ToolTipText = controlador.configuracao.ToolTipInserir;
            BtnEditar.ToolTipText = controlador.configuracao.ToolTipEditar;
            BtnExcluir.ToolTipText = controlador.configuracao.ToolTipExcluir;
            BtnFiltrar.ToolTipText = controlador.configuracao.ToolTipFiltrar;
            BtnGerarPdf.ToolTipText = controlador.configuracao.ToolTipGerarPdf;
        }

        private void ConfigurarBotoes(ControladorBase controlador)
        {
            BtnInserir.Enabled = controlador.configuracao.BtnAdicionar.Enabled;
            BtnEditar.Enabled = controlador.configuracao.BtnEditar.Enabled;
            BtnExcluir.Enabled = controlador.configuracao.BtnExcluir.Enabled;
            BtnFiltrar.Enabled = controlador.configuracao.BtnFiltrar.Enabled;
            BtnGerarPdf.Enabled = controlador.configuracao.BtnGerarPdf.Enabled;
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