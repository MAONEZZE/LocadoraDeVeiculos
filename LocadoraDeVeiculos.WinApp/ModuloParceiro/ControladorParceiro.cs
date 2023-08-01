using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloParceiro;

namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    internal class ControladorParceiro : ControladorBase
    {
        private readonly ServicoParceiro servicoParceiro;

        private readonly IRepositorioParceiro repositorioParceiro;

        private TabelaParceiroControl tabelaParceiro;

        public ControladorParceiro(ServicoParceiro servicoParceiro, IRepositorioParceiro repositorioParceiro)
        {
            this.servicoParceiro = servicoParceiro;
            this.repositorioParceiro = repositorioParceiro;
        }

        public override void Inserir()
        {
            var telaParceiro = new TelaParceiroForm()
            {
                Text = "Cadastrar Parceiro"
            };

            telaParceiro.ConfigurarParceiro(new Parceiro());

            telaParceiro.onGravarRegistro += servicoParceiro.Inserir;

            if (telaParceiro.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }
        public override void Excluir()
        {
            var id = tabelaParceiro.ObtemIdSelecionado();

            if (id == default) return;

            var parceiro = repositorioParceiro.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluir o parceiro {parceiro}?", "Excluir Parceiro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoParceiro.Excluir(parceiro);

            if (result.IsFailed)
            {
                var erros = result.Errors.Select(x => x.Message).ToList();

                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
            }

            else
                AtualizarListagem();
        }

        public override void Editar()
        {

            var id = tabelaParceiro.ObtemIdSelecionado();

            if (id == default) return;

            var parceiro = repositorioParceiro.SelecionarPorId(id);

            var telaParceiro = new TelaParceiroForm()
            {
                Text = "Editar Parceiro",
            };

            telaParceiro.ConfigurarParceiro(parceiro);

            telaParceiro.onGravarRegistro += servicoParceiro.Editar;

            if (telaParceiro.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxParceiro();
        }

        public override UserControl ObtemListagem()
        {
            tabelaParceiro ??= new TabelaParceiroControl();

            AtualizarListagem();

            return tabelaParceiro;
        }

        private void AtualizarListagem()
        {
            var listagem = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Parceiro> listagem)
        {
            var sufixo = listagem.Count > 1 ? "s" : "";

            mensagemRodape = $"Visualizando {listagem.Count} parceiro{sufixo}.";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

    }
}
