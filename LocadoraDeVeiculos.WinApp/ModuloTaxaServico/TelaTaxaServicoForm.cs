using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System.Globalization;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    public partial class TelaTaxaServicoForm : Form
    {
        public event GravarRegistroDelegate<TaxaServico> onGravarRegistro;

        TaxaServico taxaServico;

        public TelaTaxaServicoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        public void ConfigurarTela(TaxaServico taxaServico)
        {
            txtNome.Text = taxaServico.Nome;

            txtPreco.Text = (taxaServico.Preco/100).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

            if (taxaServico.TipoCalculo == EnumTipoCalculo.Fixo)
            {
                rbnFixo.Checked = true;
            }
            else if (taxaServico.TipoCalculo == EnumTipoCalculo.Diario)
            {
                rbnDiario.Checked = true;
            }

            this.taxaServico = taxaServico;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            taxaServico ??= new TaxaServico();

            taxaServico.Nome = txtNome.Text;

            double preco = double.Parse(txtPreco.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR")) * 100;

            taxaServico.Preco = Convert.ToInt32(preco);

            if (rbnFixo.Checked)
            {
                taxaServico.TipoCalculo = EnumTipoCalculo.Fixo;
            }
            else if (rbnDiario.Checked)
            {
                taxaServico.TipoCalculo = EnumTipoCalculo.Diario;
            }

            Result resultado = onGravarRegistro(taxaServico);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
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
