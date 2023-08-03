using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

        Aluguel aluguel;

        public TelaAluguelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();
        }

        internal void ConfigurarRegistro(Aluguel aluguelSelecionado)
        {
            this.aluguel = aluguelSelecionado;
        }

        private void TelaAluguelForm_Load(object sender, EventArgs e)
        {

        }

        private void TelaAluguelForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
