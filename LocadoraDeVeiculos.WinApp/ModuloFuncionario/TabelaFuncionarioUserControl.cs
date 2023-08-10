using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioUserControl : UserControl
    {
        public TabelaFuncionarioUserControl()
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

                new DataGridViewTextBoxColumn { Name = "DataAdmissao", HeaderText = "Data de Admissão"},

                new DataGridViewTextBoxColumn { Name = "Salario", HeaderText = "Salário"},

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Funcionario> listaFuncionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in listaFuncionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.DataAdmissao.ToShortDateString(), $"R$ {funcionario.Salario}");
            }
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
