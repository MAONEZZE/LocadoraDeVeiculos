using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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

                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone"},
                       
                new DataGridViewTextBoxColumn { Name = "Documento", HeaderText = "Documento"},

                new DataGridViewTextBoxColumn { Name = "CNH", HeaderText = "CNH"},
                
                new DataGridViewTextBoxColumn {Name = "Validade", HeaderText = "Validade CNH"}
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Condutor> listaCondutor)
        {
            grid.Rows.Clear();

            foreach (Condutor condutor in listaCondutor)
            {
                grid.Rows.Add(condutor.Id, condutor.Nome, condutor.Telefone, condutor.Documento, condutor.Cnh, condutor.Validade);
            }
        }
    }
}
