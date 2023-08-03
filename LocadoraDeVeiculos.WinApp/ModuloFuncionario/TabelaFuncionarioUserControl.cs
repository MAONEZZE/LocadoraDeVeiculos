using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.DataAdmissao, $"R$ {funcionario.Salario/100}");
            }
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
