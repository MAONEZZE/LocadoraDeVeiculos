using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        Parceiro parceiro;

        public TelaParceiroForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public void ConfigurarParceiro(Parceiro parceiro)
        {
            txtNome.Text = parceiro.Nome;

            this.parceiro = parceiro;
        }


        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            parceiro.Nome = txtNome.Text;

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }


        }
    }
}
