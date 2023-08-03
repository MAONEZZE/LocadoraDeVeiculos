using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;

        private readonly ServicoFuncionario servicoFuncionario;

        private TabelaFuncionarioUserControl tabelaFuncionario;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario, IRepositorioFuncionario repositoriorFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
            this.repositorioFuncionario = repositoriorFuncionario;
        }

        public override void Editar()
        {
            Guid guidFuncionario = tabelaFuncionario.ObterIdSelecionado();

            if (guidFuncionario == null)
            {
                MessageBox.Show($"Selecione um Funcionário para poder editar!",
                                 "Edição de Funcionário",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                return;
            }

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(guidFuncionario);

            TelaFuncionarioForm telaFuncionario = new TelaFuncionarioForm
            {
                Text = "Editar Funcionário"
            };

            telaFuncionario.onGravarRegistro += servicoFuncionario.Editar;

            telaFuncionario.ConfigurarTela(funcionarioSelecionado);

            DialogResult resultado = telaFuncionario.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            Guid guidFuncionario = tabelaFuncionario.ObterIdSelecionado();

            if (guidFuncionario == default(Guid))
            {
                MessageBox.Show($"Selecione um Funcionário para poder excluir!",
                                  "Exclusão de Funcionário",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);
                return;
            }

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarPorId(guidFuncionario);
            
            DialogResult opcaoEscolhida = MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{funcionarioSelecionado.Nome}] ?",
                                                            "Exclusão de Funcionário",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
            if(opcaoEscolhida == DialogResult.Yes)
            {
                Result resultado = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultado.IsFailed)
                {
                    string[] erros = resultado.Errors.Select(e => e.Message).ToArray();

                    TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                    return;
                }

                AtualizarListagem();
            }

        }

        public override void Inserir()
        {
            TelaFuncionarioForm telaFuncionario = new TelaFuncionarioForm
            {
                Text = "Inserir Funcionário"
            };

            telaFuncionario.onGravarRegistro += servicoFuncionario.Inserir;

            DialogResult resultado = telaFuncionario.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            tabelaFuncionario ??= new TabelaFuncionarioUserControl();

            AtualizarListagem();

            return tabelaFuncionario;
        }

        private void AtualizarListagem()
        {
            var listagem = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Funcionario> listagem)
        {
            mensagemRodape = $"Visualizando {listagem.Count} de Funcionários.";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
