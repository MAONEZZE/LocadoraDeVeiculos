using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelUserControl : UserControl
    {
        public TabelaAluguelUserControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Visible = false },

                new DataGridViewTextBoxColumn { Name = "NomeCondutor", HeaderText = "Nome do Condutor" },

                new DataGridViewTextBoxColumn { Name = "Veiculo", HeaderText = "Veículo" },

                new DataGridViewTextBoxColumn { Name = "DataSaida", HeaderText = "Data de Saída"},

                new DataGridViewTextBoxColumn { Name = "DevolucaoPrevisao", HeaderText = "Devolução Prevista"},

                new DataGridViewTextBoxColumn { Name = "DataDevolucao", HeaderText = "Data de Devolução"},

                new DataGridViewTextBoxColumn { Name = "ValorInicial", HeaderText = "Valor Inicial"},

                new DataGridViewTextBoxColumn { Name = "ValorTotal", HeaderText = "Valor Total Final"},
            };

            return colunas;
        }

        internal void AtualizarRegistros(List<Aluguel> listagem)
        {
            grid.Rows.Clear();

            foreach (Aluguel aluguel in listagem)
            {
                string dataDevolucao = aluguel.DataDevolucao == default(DateTime) ? "Não devolvido" : aluguel.DataDevolucao.ToShortDateString();
                
                string valorTotal = aluguel.ValorTotal == 0 ? "Não devolvido" : $"R$ {aluguel.ValorTotal}";

                grid.Rows.Add(aluguel.Id, aluguel.Condutor.Nome, aluguel.Automovel.Modelo, aluguel.DataLocacao.ToShortDateString(), aluguel.DataDevolucaoPrevista.ToShortDateString(), dataDevolucao, aluguel.ValorTotalPrevisto, aluguel.ValorTotal);
            }
        }

        internal Guid ObterIdSelecionado()
        {
           return grid.SelecionarId();
        }
    }
}
