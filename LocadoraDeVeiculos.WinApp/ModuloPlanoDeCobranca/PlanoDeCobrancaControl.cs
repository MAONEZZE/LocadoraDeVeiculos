using LocadoraDeVeiculos.Dominio.ModuloCliente;
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome" },

                new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { Name = "TipoCliente", HeaderText = "Tipo de Documento"},

                new DataGridViewTextBoxColumn { Name = "Documento", HeaderText = "Documento"},

                new DataGridViewTextBoxColumn { Name = "EnderecoCep", HeaderText = "CEP"},

                new DataGridViewTextBoxColumn { Name = "EnderecoNum", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { Name = "EnderecoCidade", HeaderText = "Cidade"},
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
                grid.Rows.Add(plano.Id, plano.NomePlano, plano.PrecoDiaria, plano.PrecoKm);
            }
        }
    }
}
