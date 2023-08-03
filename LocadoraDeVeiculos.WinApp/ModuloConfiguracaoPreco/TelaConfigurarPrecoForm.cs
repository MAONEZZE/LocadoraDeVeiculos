using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracaoPreco
{
    public delegate void onGravarConfiguracao(PrecoCombustivel conf);

    public partial class TelaConfigurarPrecoForm : Form
    {
        public PrecoCombustivel configuracao;

        public onGravarConfiguracao onGravarConfiguracao;

        public TelaConfigurarPrecoForm(PrecoCombustivel configuracao)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.configuracao = configuracao;

            txtGasolina.Value = this.configuracao.Gasolina;
            txtEtanol.Value = this.configuracao.Etanol;
            txtDiesel.Value = this.configuracao.Diesel;
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            configuracao.Gasolina = txtGasolina.Value;
            configuracao.Etanol = txtEtanol.Value;
            configuracao.Diesel = txtDiesel.Value;

            var result = configuracao.Validar();

            if (result.IsFailed)
            {
                string erro = result.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
            else
            {
                onGravarConfiguracao(configuracao);
            }

        }

    }
}
