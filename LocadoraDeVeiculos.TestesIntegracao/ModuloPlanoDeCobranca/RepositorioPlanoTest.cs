using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;


namespace LocadoraDeVeiculos.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoTest : RepositorioBaseTests
    {
        private GrupoAutomovel gp;
        public RepositorioPlanoTest()
        {
            gp = Builder<GrupoAutomovel>.CreateNew().Persist();
        }

        [TestMethod]
        public void DeveInserir_Plano()
        {
            //Arrange
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(p => p.GrupoAutomovel = gp).Build();

            //Act
            repositorioPlanoDeCobranca.Inserir(plano);

            dbContext.GravarDados();

            //Assert

            repositorioPlanoDeCobranca.SelecionarPorId(plano.Id).Should().Be(plano);

        }
    }
}
