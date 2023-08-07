using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
namespace LocadoraDeVeiculos.TestesIntegracao
{
    [TestClass]
   
    public class RepositorioCupomTest : RepositorioBaseTests
    {
        Parceiro parceiro;

        public RepositorioCupomTest() : base()
        {
            parceiro = Builder<Parceiro>.CreateNew().Persist();
        }


        [TestMethod]
        public void Deve_inserir_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();

            cupom.Parceiro = parceiro;

            repositorioCupom.Inserir(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id)
                .Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();

            cupom.Parceiro = parceiro;

            repositorioCupom.Inserir(cupom);

            cupom = repositorioCupom.SelecionarPorId(cupom.Id);

            cupom.Valor = 100;

            repositorioCupom.Editar(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id)
                .Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();

            cupom.Parceiro = parceiro;

            repositorioCupom.Inserir(cupom);

            cupom = repositorioCupom.SelecionarPorId(cupom.Id);

            repositorioCupom.Excluir(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id)
               .Should().BeNull();
        }
    }
}
