using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.TestesIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloAluguel
{
    [TestClass]
    public class RepositorioAluguelTest : RepositorioBaseTests
    {
        [TestMethod]
        public void Deve_inserir_aluguel()
        {
            var aluguel = Builder<Aluguel>.CreateNew().Build();

            Funcionario funcionario = Builder<Funcionario>.CreateNew().Build();

            repositorioFuncionario.Inserir(funcionario);

            aluguel.Funcionario = funcionario;

            Cliente cliente = Builder<Cliente>.CreateNew().Build();

            repositorioCliente.Inserir(cliente);

            aluguel.Cliente = cliente;

            Condutor condutor = Builder<Condutor>.CreateNew().Build();

            repositorioCondutor.Inserir(condutor);

            aluguel.Condutor = condutor;

            GrupoAutomovel grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Build();

            repositorioGrupoAutomovel.Inserir(grupoAutomovel);

            aluguel.GrupoAutomovel = grupoAutomovel;

            Automovel automovel = Builder<Automovel>.CreateNew().Build();

            repositorioAutomovel.Inserir(automovel);

            aluguel.Automovel = automovel;

            PlanoDeCobranca planoDeCobranca = Builder<PlanoDeCobranca>.CreateNew().Build();

            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            aluguel.PlanoDeCobranca = planoDeCobranca;

            TaxaServico taxaServico = Builder<TaxaServico>.CreateNew().Build();

            repositorioTaxaServico.Inserir(taxaServico);

            aluguel.TaxasServicos.Add(taxaServico);

            aluguel.DataLocacao = DateTime.Now;

            aluguel.DataDevolucaoPrevista = DateTime.Now.AddDays(1);

            repositorioAluguel.Inserir(aluguel);

            dbContext.SaveChanges();

            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().Be(aluguel);
        }

        [TestMethod]
        public void Deve_Editar_Aluguel()
        {
            var aluguel = Builder<Aluguel>.CreateNew().Persist();

            aluguel = repositorioAluguel.SelecionarPorId(aluguel.Id);

            aluguel.DataDevolucaoPrevista = DateTime.Now.AddDays(2);

            repositorioAluguel.Editar(aluguel);

            dbContext.SaveChanges();

            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().Be(aluguel);
        }
        [TestMethod]
        public void Deve_excluir_aluguel_existente()
        {
            var aluguel = Builder<Aluguel>.CreateNew().Persist();

            aluguel = repositorioAluguel.SelecionarPorId(aluguel.Id);

            repositorioAluguel.Excluir(aluguel);

            dbContext.SaveChanges();

            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().BeNull();

        }
    }
}
