using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaFuncionarioForm : Form
    {
        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;

        Funcionario funcionario;

        public TelaFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }


        public void ConfigurarTela(Funcionario funcionario)
        {
            this.funcionario = funcionario;

            txtNome.Text = funcionario.Nome;

            txtDataAdmissao.Value = funcionario.DataAdmissao;

            txtSalario.Value = funcionario.Salario;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            funcionario ??= new Funcionario();

            funcionario.Nome = txtNome.Text;

            funcionario.DataAdmissao = txtDataAdmissao.Value;


            funcionario.Salario = txtSalario.Value;

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
