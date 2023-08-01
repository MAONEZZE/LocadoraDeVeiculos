using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Servico.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel
{
    public class ControladorGrupoAutomovel : ControladorBase
    {
        private readonly ServicoGrupoAutomovel servicoGrupo;

        private readonly IRepositorioGrupoAutomovel repositorioGrupo;

        private TabelaGrupoAutomovelControl tabelaGrupo;

        public ControladorGrupoAutomovel(ServicoGrupoAutomovel servicoGrupo,
            IRepositorioGrupoAutomovel repositorioGrupo)
        {
            this.servicoGrupo = servicoGrupo;
            this.repositorioGrupo = repositorioGrupo;
        }

        public override void Inserir()
        {
            var telaGrupo = new TelaGrupoAutomovelForm()
            {
                Text = "Cadastrar Grupo de Automóvel"
            };

            telaGrupo.onGravarRegistro += servicoGrupo.Inserir;

            telaGrupo.ConfigurarGrupo(new GrupoAutomovel());

            if (telaGrupo.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Editar()
        {
            var id = tabelaGrupo.ObtemIdSelecionado();

            if (id == 0) return;

            var grupoSelecionado = repositorioGrupo.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma editar o grupo Id: {grupoSelecionado.Id}?", "Editar Grupo de Automóvel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaGrupo = new TelaGrupoAutomovelForm()
            {
                Text = "Editar Grupo de Automóvel"
            };

            telaGrupo.onGravarRegistro += servicoGrupo.Editar;

            telaGrupo.ConfigurarGrupo(grupoSelecionado);

            if (telaGrupo.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }


        public override void Excluir()
        {
            var id = tabelaGrupo.ObtemIdSelecionado();

            if (id == 0) return;

            var grupoSelecionado = repositorioGrupo.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o grupo Id: {grupoSelecionado.Id}?", "Editar Grupo de Automóvel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoGrupo.Excluir(grupoSelecionado);

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
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaGrupo ??= new TabelaGrupoAutomovelControl();
            AtualizarListagem();

            return tabelaGrupo;
        }

        private void AtualizarListagem()
        {
            var listagem = repositorioGrupo.SelecionarTodos();

            tabelaGrupo.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<GrupoAutomovel> listagem)
        {
            var sufixo = listagem.Count > 1 ? "s" : "";

            mensagemRodape = $"Visualizando {listagem.Count} grupo{sufixo}.";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

    }
}
