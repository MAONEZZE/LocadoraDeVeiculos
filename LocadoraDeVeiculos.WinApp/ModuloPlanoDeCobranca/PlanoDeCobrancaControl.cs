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

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo do Plano" },

                new DataGridViewTextBoxColumn { Name = "ValorDia", HeaderText = "Valor por Dia" },

                new DataGridViewTextBoxColumn { Name = "KmLivre", HeaderText = "Km Livre" },

                new DataGridViewTextBoxColumn { Name = "ValorKmRodado", HeaderText = "Valor do Km Rodado" },

                new DataGridViewTextBoxColumn { Name = "NomeGPAuto", HeaderText = "Grupo de Automovel" },
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

            foreach (PlanoDeCobranca plano in listaPlanos)
            {
                string kmLivre = (plano.TipoPlano == TipoPlanoEnum.Livre)? "Sim" : "Não";

                grid.Rows.Add(plano.Id, plano.TipoPlano, plano.PrecoDiaria, kmLivre, plano.PrecoKm, plano.GrupoAutomovel.Nome);
            }
        }
    }
}
