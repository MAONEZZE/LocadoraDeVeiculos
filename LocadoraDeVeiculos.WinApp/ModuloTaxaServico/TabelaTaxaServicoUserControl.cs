using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    public partial class TabelaTaxaServicoUserControl : UserControl
    {
        public TabelaTaxaServicoUserControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Visible = false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome" },

                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço"},

            };

            return colunas;
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<TaxaServico> listaTaxaServico)
        {
            grid.Rows.Clear();

            foreach (TaxaServico taxaServico in listaTaxaServico)
            {
                grid.Rows.Add(taxaServico.Id, taxaServico.Nome, $"R$ {taxaServico.Preco}");
            }
        }
    }
}
