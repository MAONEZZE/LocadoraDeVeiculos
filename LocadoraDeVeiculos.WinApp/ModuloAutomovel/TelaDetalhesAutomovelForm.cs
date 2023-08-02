using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public partial class TelaDetalhesAutomovelForm : Form
    {

        ManipuladorImagem manipulador;
        public TelaDetalhesAutomovelForm(ManipuladorImagem manipuladorImagem, Automovel automovel)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            manipulador = manipuladorImagem;

            txtGrupo.Text = automovel.GrupoAutomovel.Nome;
            pictureBoxFoto.Image = manipulador.ConverterParaImagem(automovel.Foto.ImagemBytes);
            txtCombustivel.Text = automovel.Combustivel.ToString();
            txtAno.Text = automovel.Ano.ToString();
            txtCor.Text = automovel.Cor;
            txtKm.Text = automovel.Quilometragem.ToString();
            txtLitros.Text = automovel.CapacidadeDeCombustivel.ToString();
            txtMarca.Text = automovel.Marca;
            txtModelo.Text = automovel.Modelo;
            txtPlaca.Text = automovel.Placa;
        }



        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
