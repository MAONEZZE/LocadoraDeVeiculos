using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCupom;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repCliente;
        private ServicoCliente servicoCliente;
        private TabelaClienteControl tabelaCliente;

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
            
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCupom();
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
