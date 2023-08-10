using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloCupom
{
    public delegate List<Parceiro> onObterParceiroDelegate();

    public partial class TelaCupomForm : Form
    {
        public event GravarRegistroDelegate<Cupom> onGravarRegistro;

        public onObterParceiroDelegate OnObterParceiro_;

        Cupom cupom;

        public TelaCupomForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
           
        }


        private void BtnSalvar_Click(object sender, EventArgs e)
        {          
            cupom.Valor = txtValor.Value;
            cupom.DataValidade = txtData.Value;
            cupom.Nome = txtNome.Text;
            cupom.Parceiro = (Parceiro)txtComboParceiro.SelectedItem;

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public void ConfigurarCupom(Cupom cupom)
        {
          
            txtNome.Text = cupom.Nome;

            txtData.Value = cupom.DataValidade == default ? DateTime.Now : cupom.DataValidade;

            txtValor.Value = cupom.Valor;

            txtComboParceiro.DataSource = OnObterParceiro_();

            if (cupom.Parceiro != null)
                txtComboParceiro.SelectedItem = cupom.Parceiro;

            this.cupom = cupom;
        }
    }
}
