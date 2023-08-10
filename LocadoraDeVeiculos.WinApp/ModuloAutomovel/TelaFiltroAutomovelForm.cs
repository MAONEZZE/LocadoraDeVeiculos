using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public partial class TelaFiltroAutomovelForm : Form
    {


        public GrupoAutomovel grupoAutomovel;

        public TelaFiltroAutomovelForm(List<GrupoAutomovel> grupos)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            comboGrupo.DataSource = grupos;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (checkTodos.Checked == false)
                grupoAutomovel = (GrupoAutomovel)comboGrupo.SelectedItem;
        }

        private void checkTodos_CheckedChanged(object sender, EventArgs e)
        {
            comboGrupo.Enabled = !comboGrupo.Enabled;
        }
    }
}
