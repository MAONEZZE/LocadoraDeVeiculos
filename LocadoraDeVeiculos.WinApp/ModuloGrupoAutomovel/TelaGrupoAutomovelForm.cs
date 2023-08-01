using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel
{
    public partial class TelaGrupoAutomovelForm : Form
    {
        public event GravarRegistroDelegate<GrupoAutomovel> onGravarRegistro;

        private GrupoAutomovel grupo;

      

        public TelaGrupoAutomovelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        public void ConfigurarGrupo(GrupoAutomovel grupo)
        {
           
            txtNome.Text = grupo.Nome;

            this.grupo = grupo;
        }


        private void BtnSalvar_Click(object sender, EventArgs e)
        {         
            grupo.Nome = txtNome.Text;

            Result resultado = onGravarRegistro(grupo);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }


        }
    }
}
