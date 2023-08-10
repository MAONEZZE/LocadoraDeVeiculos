using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.TestesIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloTaxaServicos
{
    [TestClass]
    public class RepositorioTaxaServicoTest : RepositorioBaseTests
    {
        [TestMethod]
        public void Deve_inserir_taxaServico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Build();

            repositorioTaxaServico.Inserir(taxaServico);

            dbContext.SaveChanges();

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().Be(taxaServico);
        }

        [TestMethod]
        public void Deve_editar_taxaservico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServico.Id);

            taxaServico.Nome = "TaxaServico Teste";

            repositorioTaxaServico.Editar(taxaServico);

            dbContext.SaveChanges();

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().Be(taxaServico);
        }

        [TestMethod]

        public void Deve_excluir_taxaServico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            taxaServico = repositorioTaxaServico.SelecionarPorId(taxaServico.Id);

            repositorioTaxaServico.Excluir(taxaServico);

            dbContext.SaveChanges();

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().BeNull();

        }

        [TestMethod]
        public void Deve_buscar_por_nome()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            repositorioTaxaServico.BuscarPorNome(taxaServico.Nome).Should().Be(taxaServico);
        }
    }
}
