using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    public partial class TelaTaxaServicoForm : Form
    {
        public event GravarRegistroDelegate<TaxaServico> onGravarRegistro;

        TaxaServico taxaServico;

        public TelaTaxaServicoForm()
        {
            InitializeComponent();

            taxaServico = new();
            txtPreco.TextAlign = HorizontalAlignment.Right;
            txtPreco.ValidatingType = typeof(decimal);
            txtPreco.Validating += new System.ComponentModel.CancelEventHandler(txtPreco_Validating);
        }
        public void ConfigurarTela(TaxaServico taxaServico)
        {
            txtNome.Text = taxaServico.Nome;

            txtPreco.Text = taxaServico.Preco.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

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
        private void txtPreco_Validating(object sender, CancelEventArgs e)
        {
            decimal valor;
            if (!decimal.TryParse(txtPreco.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out valor))
            {
                MessageBox.Show("Valor monetário inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                txtPreco.Text = valor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            taxaServico.Nome = txtNome.Text;

            double preco = double.Parse(txtPreco.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR")) * 100;

            taxaServico.Preco = Convert.ToInt32(preco);

            if(rbnFixo.Checked)
            {
                taxaServico.TipoCalculo = EnumTipoCalculo.Fixo;
            }
            else if(rbnDiario.Checked)
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
