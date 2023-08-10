using iTextSharp.text;
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
            var telaAutomovel = new TelaAutomovelForm(new ManipuladorImagem())
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
            var id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == default) return;

            var automovel = repositorioAutomovel.SelecionarPorId(id);
         
            var opcao = MessageBox.Show($"Confirma editar o automóvel placa: {automovel.Placa}?", "Editar Automóvel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaAutomovel = new TelaAutomovelForm(new ManipuladorImagem())
            {
                Text = "Editar Automóvel"
            };

            telaAutomovel.gravarRegistroDelegate += servicoAutomovel.Editar;

            telaAutomovel.onBuscarGrupo += repositorioGrupoAutomovel.SelecionarTodos;

            telaAutomovel.ConfigurarAutomovel(automovel);
       
            if (telaAutomovel.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            var id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == default) return;

            var automovel = repositorioAutomovel.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o automóvel placa: {automovel.Placa}?", "Excluír Automóvel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoAutomovel.Excluir(automovel);

            if (result.IsFailed)
            {
                var erros = result.Errors.Select(x => x.Message).ToList();

                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
            }

            else
                AtualizarListagem();
        }

        public override void Filtrar()
        {
            var telaFiltro = new TelaFiltroAutomovelForm(repositorioGrupoAutomovel.SelecionarTodos())
            {
                Text = "Filtrar Automóveis"
            };


            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                var grupo = telaFiltro.grupoAutomovel;

                List<Automovel> listagem;

                if (grupo == null)
                    listagem = repositorioAutomovel.SelecionarTodos();

                else
                 listagem = repositorioAutomovel.SelecionarPorGrupoAutomovel(grupo);

                tabelaAutomovel.AtualizarRegistros(listagem);

                AtualizarRodape(listagem);
            }
        }

        public override void Visualizar()
        {
            var id = tabelaAutomovel.ObtemIdSelecionado();

            if (id == default) return;

            var automovel = repositorioAutomovel.SelecionarPorId(id);

            var telaDetalhes = new TelaDetalhesAutomovelForm(new ManipuladorImagem(), automovel)
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
