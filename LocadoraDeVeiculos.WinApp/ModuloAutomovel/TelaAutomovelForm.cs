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

        bool alterouImagem;

        public OnBuscarGrupoDelegate onBuscarGrupo;

        public GravarRegistroDelegate<Automovel> gravarRegistroDelegate;

        public TelaAutomovelForm(ManipuladorImagem manipuladorImagem)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            manipulador = manipuladorImagem;

        }


        public void ConfigurarAutomovel(Automovel automovel)
        {
            this.automovel = automovel;

            comboBoxGrupo.DataSource = onBuscarGrupo();

            comboBoxCombustivel.DataSource = Enum.GetValues<TipoCombustivelEnum>();

            SelecionarCombustivel(automovel);

            if (automovel.GrupoAutomovel != null)
                SelecionarGrupoAutomovel(automovel);

            if (automovel.Foto != null)
                SelecionarFoto(automovel);

            txtAno.Value = automovel.Ano;
            txtCor.Text = automovel.Cor;
            txtKm.Value = automovel.Quilometragem;
            txtLitros.Value = automovel.CapacidadeDeCombustivel;
            txtMarca.Text = automovel.Marca;
            txtModelo.Text = automovel.Modelo;
            txtPlaca.Text = automovel.Placa;
        }

        private void SelecionarFoto(Automovel automovel)
        {
            pictureBoxFoto.Image = manipulador.ConverterParaImagem(automovel.Foto.ImagemBytes);
        }

        private void SelecionarCombustivel(Automovel automovel)
        {
            foreach (var item in comboBoxCombustivel.Items)
            {
                if (automovel.Combustivel.Equals(item))
                    comboBoxCombustivel.SelectedItem = item;
            }
        }


        private void SelecionarGrupoAutomovel(Automovel automovel)
        {
            foreach (var item in comboBoxGrupo.Items)
            {
                if (automovel.GrupoAutomovel.Equals(item))
                    comboBoxGrupo.SelectedItem = item;
            }

        }

        private void BntBuscarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imagem = manipulador.RedimensionarImagem(openFileDialog.FileName);

                    pictureBoxFoto.Image = imagem;

                    alterouImagem = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

            else if (alterouImagem)
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
