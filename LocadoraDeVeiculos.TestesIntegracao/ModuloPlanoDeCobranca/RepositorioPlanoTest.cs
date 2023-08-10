using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.TestesIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoTest : RepositorioBaseTests
    {
        private GrupoAutomovel grupo;
        public RepositorioPlanoTest()
        {
            grupo = Builder<GrupoAutomovel>.CreateNew().Persist();
        }

        [TestMethod]
        public void DeveInserir_Plano()
        {
            //Arrange
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(p => p.GrupoAutomovel = grupo).Build();

            //Act
            repositorioPlanoDeCobranca.Inserir(plano);

            dbContext.GravarDados();

            //Assert

            repositorioPlanoDeCobranca.SelecionarPorId(plano.Id).Should().Be(plano);

        }

        [TestMethod]
        public void DeveEditarPlanoCobranca()
        {
          
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            repositorioPlanoDeCobranca.Editar(plano);

            repositorioPlanoDeCobranca.SelecionarPorId(plano.Id).Should().Be(plano);
        }

        [TestMethod]
        public void DeveExcluirPlanoCobranca()
        {
           
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            repositorioPlanoDeCobranca.Excluir(plano);

            dbContext.GravarDados();

            repositorioPlanoDeCobranca.SelecionarPorId(plano.Id).Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodos()
        {
           
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();
            var plano2 = Builder<PlanoDeCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            var list = repositorioPlanoDeCobranca.SelecionarTodos();

            list[0].Should().Be(plano);
            list[1].Should().Be(plano2);

            list.Should().HaveCount(2);
        }

        [TestMethod]
        public void DeveSelecionarPorId()
        {       
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            var planoSelecionado = repositorioPlanoDeCobranca.SelecionarPorId(plano.Id);

            planoSelecionado.Should().Be(plano);
        }
    }
}
