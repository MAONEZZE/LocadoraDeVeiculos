using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Servico.ModuloAutomovel;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {

        private readonly IRepositorioAutomovel repositorioAutomovel;

        private readonly IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        private readonly ServicoAutomovel servicoAutomovel;

        private TabelaAutomovelControl tabelaAutomovel;

        public ControladorAutomovel(
            IRepositorioAutomovel repositorioAutomovel,
            IRepositorioGrupoAutomovel repositorioGrupoAutomovel,
            ServicoAutomovel servicoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoAutomovel = servicoAutomovel;
        }

        public override void Inserir()
        {
            var telaAutomovel = new TelaAutomovelForm()
            {
                Text = "Cadastrar Automóvel"
            };

            telaAutomovel.gravarRegistroDelegate += servicoAutomovel.Inserir;

            telaAutomovel.onBuscarGrupo += repositorioGrupoAutomovel.SelecionarTodos;

            telaAutomovel.ConfigurarAutomovel(new Automovel());

            if (telaAutomovel.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Visualizar()
        {
            var id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == default) return;

            var automovel = repositorioAutomovel.SelecionarPorId(id);

            var telaDetalhes = new TelaDetalhesAutomovelForm(automovel)
            {
                Text = "Detalhes Automóvel"
            };

            telaDetalhes.ShowDialog();
        }

        public override UserControl ObtemListagem()
        {
            tabelaAutomovel ??= new TabelaAutomovelControl();

            AtualizarListagem();

            return tabelaAutomovel;
        }

        private void AtualizarListagem()
        {
            var listagem = repositorioAutomovel.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Automovel> listagem)
        {
            var sufixo = listagem.Count > 1 ? "is" : "l";

            mensagemRodape = $"Visualizando {listagem.Count} automóve{sufixo}.";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAutomovel();
        }
    }
}
