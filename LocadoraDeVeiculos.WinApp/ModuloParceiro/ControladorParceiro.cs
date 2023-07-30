using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    internal class ControladorParceiro : ControladorBase
    {
        ServicoParceiro servicoParceiro;

        IRepositorioParceiro repositorioParceiro;

        TabelaParceiroControl tabelaParceiro;

        public ControladorParceiro(ServicoParceiro servicoParceiro, IRepositorioParceiro repositorioParceiro)
        {
            this.servicoParceiro = servicoParceiro;
            this.repositorioParceiro = repositorioParceiro;
        }

        public override void Inserir()
        {
            var telaParceiro = new ParceiroTelaForm();

            telaParceiro.onGravarRegistro += servicoParceiro.Inserir;

            if (telaParceiro.ShowDialog() == DialogResult.OK)
            {
                ObtemListagem();
            }
        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }



        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxParceiro();
        }

        public override UserControl ObtemListagem()
        {
            tabelaParceiro ??= new TabelaParceiroControl();

            var listagem = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(listagem);

            EnviarMensagem(listagem);

            return tabelaParceiro;
        }

        private void EnviarMensagem(List<Parceiro> listagem)
        {
            var sufixo = listagem.Count > 1 ? "s" : "";

            mensagemRodape = $"Visualizando {listagem.Count} parceiro{sufixo}";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

    }
}
