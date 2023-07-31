

using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        Parceiro parceiro;

        int id; 

        public TelaParceiroForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();                 
        }

        public void ConfiguararParceiro(Parceiro parceiro)
        {
            id = parceiro.Id;

            txtNome.Text = parceiro.Nome;

            this.parceiro = parceiro;
        }

       
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            parceiro.Id = id;

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
