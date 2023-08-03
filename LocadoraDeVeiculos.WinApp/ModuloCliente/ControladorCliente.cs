using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCliente;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repCliente = null!;
        private ServicoCliente servicoCliente = null!;
        
        private TabelaClienteControl tabelaCliente = null!;

        public ControladorCliente(IRepositorioCliente repCliente, ServicoCliente servicoCliente)
        {
            this.repCliente = repCliente;
            this.servicoCliente = servicoCliente;
            
        }

        public override void Inserir()
        {
            var telaCliente = new TelaClienteForm() 
            {
                Text = "Cadastrar Cliente"
            };

            telaCliente.onGravarRegistro += servicoCliente.Inserir;

            telaCliente.ConfigurarCliente(new Cliente());

            if (telaCliente.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }

        }

        public override void Editar()
        {
            var id = tabelaCliente.ObtemIdSelecionado();

            if (id == default) return;

            var cliente = repCliente.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma editar o cliente: {cliente.Nome}?", "Editar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaCliente = new TelaClienteForm
            {
                Text = "Editar Cliente"
            };

            telaCliente.onGravarRegistro += servicoCliente.Editar;

            telaCliente.ConfigurarCliente(cliente);

            if (telaCliente.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            var id = tabelaCliente.ObtemIdSelecionado();

            if (id == default) return;

            var cliente = repCliente.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o cliente: {cliente.Nome}?", "Excluír cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoCliente.Excluir(cliente);

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
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if(tabelaCliente == null)
            {
                tabelaCliente = new TabelaClienteControl();
            }

            AtualizarListagem();

            return tabelaCliente;
        }

        private void AtualizarListagem()
        {
            var listagem = repCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Cliente> listagem)
        {
            var sufixo = listagem.Count > 1 ? "s" : "";

            mensagemRodape = $"Visualizando {listagem.Count} cliente{sufixo}";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
