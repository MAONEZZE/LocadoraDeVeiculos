using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracaoPreco
{
    public delegate void onGravarConfiguracao(PrecoCombustivel conf);

    public partial class TelaPrecoCombustivelForm : Form
    {
        public PrecoCombustivel configuracao;

        public onGravarConfiguracao onGravarConfiguracao;

        public TelaPrecoCombustivelForm(PrecoCombustivel configuracao)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.configuracao = configuracao;

            txtGasolina.Value = this.configuracao.Gasolina;
            txtEtanol.Value = this.configuracao.Etanol;
            txtDiesel.Value = this.configuracao.Diesel;
            txtGas.Value = this.configuracao.Gas;

        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            configuracao.Gasolina = txtGasolina.Value;
            configuracao.Etanol = txtEtanol.Value;
            configuracao.Diesel = txtDiesel.Value;
            configuracao.Gas = txtGas.Value;

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
