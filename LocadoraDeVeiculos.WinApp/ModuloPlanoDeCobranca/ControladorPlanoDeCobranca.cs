using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Servico.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private IRepositorioGrupoAutomovel repGpAuto;
        private IRepositorioPlanoDeCobranca repPlano;
        private ServicoPlanoDeCobranca servicoPlano;
        private PlanoDeCobrancaControl tabelaPlano;

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repPlano, IRepositorioGrupoAutomovel repGpAuto, ServicoPlanoDeCobranca servicoPlano)
        {
            this.repPlano = repPlano;
            this.repGpAuto = repGpAuto;
            this.servicoPlano = servicoPlano;
        }

        public override void Editar()
        {
            var id = tabelaPlano.ObtemIdSelecionado();

            if (id == default) return;

            var plano = repPlano.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma editar o plano: {plano.TipoPlano}?", "Editar Plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaPlano = new TelaPlanoDeCobrancaForm(repGpAuto)
            {
                Text = "Editar Plano"
            };

            telaPlano.onGravarRegistro += servicoPlano.Editar;

            telaPlano.ConfigurarPlano(plano);

            if (telaPlano.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            var id = tabelaPlano.ObtemIdSelecionado();

            if (id == default) return;

            var plano = repPlano.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o plano: {plano.TipoPlano}?", "Excluír plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoPlano.Excluir(plano);

            if (result.IsFailed)
            {
                var erros = result.Errors.Select(x => x.Message).ToList();

                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
            }

            else
                AtualizarListagem();
        }

        public override void Inserir()
        {
            var telaPlano = new TelaPlanoDeCobrancaForm(repGpAuto)
            {
                Text = "Cadastrar Plano"
            };

            telaPlano.onGravarRegistro += servicoPlano.Inserir;

            telaPlano.ConfigurarPlano(new PlanoDeCobranca());

            if (telaPlano.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlano == null)
            {
                tabelaPlano = new PlanoDeCobrancaControl();
            }

            AtualizarListagem();

            return tabelaPlano;
        }

        private void AtualizarListagem()
        {
            var listagem = repPlano.SelecionarTodos();

            tabelaPlano.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<PlanoDeCobranca> listagem)
        {
            var sufixo = listagem.Count > 1 ? "s" : "";

            mensagemRodape = $"Visualizando {listagem.Count} Plano{sufixo}";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
