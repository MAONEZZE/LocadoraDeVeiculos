using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.WinApp.ModuloCupom
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            gridCupom.ConfigurarGridZebrado();
            gridCupom.ConfigurarGridSomenteLeitura();
            gridCupom.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Visible = false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome" },

                new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { Name = "Vencimento", HeaderText = "Vencimento"},

                new DataGridViewTextBoxColumn { Name = "Parceiro", HeaderText = "Parceiro"},

                new DataGridViewTextBoxColumn { Name = "EhValido", HeaderText = "Válido"},
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCupom.SelecionarId();
        }

        public void AtualizarRegistros(List<Cupom> cupons)
        {
            gridCupom.Rows.Clear();

            foreach (Cupom cupom in cupons)
            {
                gridCupom.Rows.Add(cupom.Id, cupom.Nome, $"R$ {cupom.Valor}", $"{cupom.DataValidade:d}", cupom.Parceiro.Nome, cupom.EhValido ? "Sim" : "Não");
            }
        }
    }
}
