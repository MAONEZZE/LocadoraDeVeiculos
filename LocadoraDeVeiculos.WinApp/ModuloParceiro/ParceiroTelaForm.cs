

using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    public partial class ParceiroTelaForm : Form
    {
        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        Parceiro parceiro;
     
        public Parceiro Parceiro { get => parceiro; set=> txtNome.Text = value.Nome; }
      
        public ParceiroTelaForm()
        {
            InitializeComponent();

            var nome = txtNome.Text;

            parceiro = new Parceiro(nome);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text;

            parceiro = new Parceiro(parceiro.Id, nome);

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
