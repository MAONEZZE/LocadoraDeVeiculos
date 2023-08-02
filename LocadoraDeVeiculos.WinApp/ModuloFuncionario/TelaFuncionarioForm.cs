using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System.Globalization;

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

            txtSalario.Text = (funcionario.Salario / 100).ToString();
            //txtSalario.Text = (funcionario.Salario / 100).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            funcionario ??= new Funcionario();

            funcionario.Nome = txtNome.Text;

            funcionario.DataAdmissao = txtDataAdmissao.Value;

            double salario = double.Parse(txtSalario.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR")) * 100;

            funcionario.Salario = Convert.ToInt32(salario);

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
