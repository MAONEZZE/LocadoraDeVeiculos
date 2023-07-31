using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
            gridParceiro.ConfigurarGridZebrado();
            gridParceiro.ConfigurarGridSomenteLeitura();
            gridParceiro.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridParceiro.SelecionarId();
        }

        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            gridParceiro.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                gridParceiro.Rows.Add(parceiro.Id, parceiro.Nome);
            }
        }
    }
}
