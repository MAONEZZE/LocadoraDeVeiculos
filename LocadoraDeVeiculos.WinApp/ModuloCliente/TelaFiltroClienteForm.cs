namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaFiltroClienteForm : Form
    {
        public TelaFiltroClienteForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            foreach (RadioButton rdb in rdbGroup.Controls)
            {
                rdb.Click += EscolhaRDB;
            }
        }

        private void EscolhaRDB(object? sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            
        }

        private TipoClienteEnum ObterStatus()
        {
            if (rdb_filtroCpf.Checked)
            {
                return TipoClienteEnum.CPF;
            }
            else if(rdb_filtroCnpj.Checked)
            {
                return TipoClienteEnum.CNPJ;
            }

            return TipoClienteEnum.Outro;
        }
    }
}
