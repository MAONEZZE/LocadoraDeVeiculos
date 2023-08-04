using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloCondutor;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private IRepositorioCliente repCliente = null!;
        private IRepositorioCondutor repCondutor = null!;
        private ServicoCondutor servicoCondutor = null!;
        private TabelaCondutorControl tabelaCondutor = null!;

        public ControladorCondutor(IRepositorioCondutor repCondutor, IRepositorioCliente repCliente,ServicoCondutor servicoCondutor)
        {
            this.repCondutor = repCondutor;
            this.repCliente = repCliente;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            var telaCondutor = new TelaCondutorForm(repCliente)
            {
                Text = "Cadastrar Condutor"
            };

            telaCondutor.onGravarRegistro += servicoCondutor.Inserir;

            telaCondutor.ConfigurarCondutor(new Condutor());

            if (telaCondutor.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemIdSelecionado();

            if (id == default) return;

            var condutor = repCondutor.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma editar o condutor: {condutor.Nome}?", "Editar condutor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaCondutor = new TelaCondutorForm(repCliente)
            {
                Text = "Editar Condutor"
            };

            telaCondutor.onGravarRegistro += servicoCondutor.Editar;

            telaCondutor.ConfigurarCondutor(condutor);

            if (telaCondutor.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemIdSelecionado();

            if (id == default) return;

            var condutor = repCondutor.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o condutor: {condutor.Nome}?", "Excluír condutor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcao == DialogResult.No) return;

            var result = servicoCondutor.Excluir(condutor);

            if (result.IsFailed)
            {
                var erros = result.Errors.Select(x => x.Message).ToList();

                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
            }

            else
                AtualizarListagem();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCondutor == null)
            {
                tabelaCondutor = new TabelaCondutorControl();
            }

            AtualizarListagem();

            return tabelaCondutor;
        }

        private void AtualizarListagem()
        {
            var listagem = repCondutor.SelecionarTodos();

            tabelaCondutor.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Condutor> listagem)
        {
            var sufixo = listagem.Count > 1 ? "es" : "";

            mensagemRodape = $"Visualizando {listagem.Count} condutor{sufixo}";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
