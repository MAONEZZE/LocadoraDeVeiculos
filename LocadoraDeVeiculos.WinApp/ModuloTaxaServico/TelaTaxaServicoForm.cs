using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

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

            txtPreco.Value = taxaServico.Preco;

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

            taxaServico.Preco = txtPreco.Value;

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
    }
}
