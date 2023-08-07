using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class PlanoDeCobrancaControl : UserControl
    {
        public PlanoDeCobrancaControl()
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

                new DataGridViewTextBoxColumn { Name = "NomeGPAuto", HeaderText = "Grupo de Automovel" },

                new DataGridViewTextBoxColumn { Name = "ValorDia", HeaderText = "Valor por Dia" },

                new DataGridViewTextBoxColumn { Name = "KmLivre", HeaderText = "Km Livre" },

                new DataGridViewTextBoxColumn { Name = "ValorKmRodado", HeaderText = "Valor do Km Rodado" },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo do Plano" },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> listaPlanos)
        {
            grid.Rows.Clear();
            //Id, nome, valor por dia, km livre inclusive, valor km rodado e tipo do plano

            foreach (PlanoDeCobranca plano in listaPlanos)
            {
                grid.Rows.Add(plano.Id, plano.GrupoAutomovel.Nome, plano.PrecoDiaria, plano.PrecoKm);
            }
        }
    }
}
