using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

using FluentAssertions; 


namespace LocadoraDeVeiculos.TestesIntegracao
{
    [TestClass]
    public class RepositorioParceiroTest : RepositorioBaseTests
    {
        [TestMethod]
        public void Deve_inserir_parceiro()
        {
            LimparTabelas();

            var parceiro = Builder<Parceiro>.CreateNew().Build();
     
            repositorioParceiro.Inserir(parceiro);

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }
    }
}
