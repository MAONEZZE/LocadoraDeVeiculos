using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public partial class TabelaAutomovelControl : UserControl
    {
        public TabelaAutomovelControl()
        {
            InitializeComponent();
            gridAutomovel.ConfigurarGridZebrado();
            gridAutomovel.ConfigurarGridSomenteLeitura();
            gridAutomovel.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", Visible = false },

                  new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoria" },

                new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca" },

                new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { Name = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { Name = "Combustível", HeaderText = "Combustível"},

                new DataGridViewTextBoxColumn { Name = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { Name = "Km", HeaderText = "Km"},

                new DataGridViewTextBoxColumn { Name = "Capacidade Combustivel", HeaderText = "Tanque em Litros"},

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridAutomovel.SelecionarId();
        }

        public void AtualizarRegistros(List<Automovel> automoveis)
        {
            gridAutomovel.Rows.Clear();

            foreach (var automovel in automoveis)
            {
                gridAutomovel.Rows.Add(automovel.Id, automovel.GrupoAutomovel.Nome,
                    automovel.Marca, automovel.Modelo, automovel.Cor,
                    automovel.Combustivel, automovel.Ano, automovel.Placa,
                    automovel.Quilometragem, automovel.CapacidadeDeCombustivel
                   );
            }
        }
    }
}
