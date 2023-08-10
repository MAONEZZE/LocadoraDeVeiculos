using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
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

        public void AtualizarRegistros(List<Cliente> listaCliente)
        {
            grid.Rows.Clear();

            foreach (Cliente cliente in listaCliente)
            {
                grid.Rows.Add(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone,cliente.TipoCliente.ToString(), cliente.Documento, cliente.Endereco.Cep, cliente.Endereco.Numero, cliente.Endereco.Cidade);
            }
        }
    }
}
