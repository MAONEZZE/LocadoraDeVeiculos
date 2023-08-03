using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Servico.ModuloAluguel;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;

namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private readonly IRepositorioAluguel repositorioAluguel;

        private readonly ServicoAluguel servicoAluguel;

        private TabelaAluguelUserControl tabelaAluguel;
        
        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel)
        {
            this.servicoAluguel = servicoAluguel;
            this.repositorioAluguel = repositorioAluguel;
        }

        public override void Editar()
        {
            Guid guidAluguel = tabelaAluguel.ObterIdSelecionado();

            if (guidAluguel == null)
            {
                MessageBox.Show($"Selecione um Aluguel para poder editar!",
                                 "Edição de Aluguel",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                return;
            }

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(guidAluguel);

            TelaAluguelForm telaAluguel = new TelaAluguelForm
            {
                Text = "Editar Aluguel",
            };

            telaAluguel.onGravarRegistro += servicoAluguel.Editar;

            telaAluguel.ConfigurarRegistro(aluguelSelecionado);

            DialogResult resultado = telaAluguel.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            Guid guidAluguel = tabelaAluguel.ObterIdSelecionado();

            if (guidAluguel == null)
            {
                MessageBox.Show($"Selecione um Aluguel para poder excluir!",
                                 "Exclusão de Aluguel",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                return;
            }

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(guidAluguel);

            DialogResult opcaoEscolhida = MessageBox.Show($"Tem certeza que deseja excluir o Aluguel?",
                                                            "Exclusão de Aluguel",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
            if (opcaoEscolhida == DialogResult.Yes)
            {
                Result resultado = servicoAluguel.Excluir(aluguelSelecionado);

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
            TelaAluguelForm telaAluguel = new TelaAluguelForm
            {
                Text = "Inserir Aluguel",
            };

            telaAluguel.onGravarRegistro += servicoAluguel.Inserir;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxAluguel();
        }

        public override UserControl ObtemListagem()
        {
            tabelaAluguel ??= new TabelaAluguelUserControl();

            AtualizarListagem();

            return tabelaAluguel;
        }
        private void AtualizarListagem()
        {
            var registros = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(registros);

            AtualizarRodape(registros);
        }

        private void AtualizarRodape(List<Aluguel> registros)
        {
            mensagemRodape = $"Visualizando {registros.Count} Aluguéis";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
