using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public delegate List<GrupoAutomovel> OnBuscarGrupoDelegate();

    public partial class TelaAutomovelForm : Form
    {
        ManipuladorImagem manipulador;

        Automovel automovel;

        Image imagem;

        public OnBuscarGrupoDelegate onBuscarGrupo;

        public GravarRegistroDelegate<Automovel> gravarRegistroDelegate;

        public TelaAutomovelForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

            manipulador = new ManipuladorImagem();

        }


        public void ConfigurarAutomovel(Automovel automovel)
        {
            this.automovel = automovel;

            if (automovel.GrupoAutomovel != null)
                comboBoxGrupo.SelectedItem = automovel.GrupoAutomovel;

            if (automovel.Foto != null)
                pictureBoxFoto.Image = manipulador.ConverterParaImagem(automovel.Foto.ImagemBytes);

            comboBoxGrupo.DataSource = onBuscarGrupo();

            comboBoxCombustivel.DataSource = Enum.GetValues<TipoCombustivelEnum>();

            comboBoxCombustivel.SelectedItem = automovel.GrupoAutomovel;

            txtAno.Value = automovel.Ano;
            txtCor.Text = automovel.Cor;
            txtKm.Value = automovel.Quilometragem;
            txtLitros.Value = automovel.CapacidadeDeCombustivel;
            txtMarca.Text = automovel.Marca;
            txtModelo.Text = automovel.Modelo;
            txtPlaca.Text = automovel.Placa;
        }


        private void BntBuscarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagem = manipulador.RedimensionarImagem(openFileDialog.FileName);

                pictureBoxFoto.Image = imagem;
            }

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            automovel.Ano = (int)txtAno.Value;
            automovel.Cor = txtCor.Text;
            automovel.Quilometragem = (int)txtKm.Value;
            automovel.CapacidadeDeCombustivel = (int)txtLitros.Value;
            automovel.Marca = txtMarca.Text;
            automovel.Modelo = txtModelo.Text;
            automovel.Placa = txtPlaca.Text;
            automovel.GrupoAutomovel = (GrupoAutomovel)comboBoxGrupo.SelectedItem;
            automovel.Combustivel = (TipoCombustivelEnum)comboBoxCombustivel.SelectedItem;

            if (automovel.Foto == null)
                automovel.IncluirFoto(manipulador.ConverterParaBytes(imagem));
            else
                automovel.EditarFoto(manipulador.ConverterParaBytes(imagem));

            var result = gravarRegistroDelegate(automovel);

            if (result.IsFailed)
            {
                string erro = result.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }


    }
}
