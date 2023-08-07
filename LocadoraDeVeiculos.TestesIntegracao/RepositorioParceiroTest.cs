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
            var parceiro = Builder<Parceiro>.CreateNew().Build();
     
            repositorioParceiro.Inserir(parceiro);

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_Editar_Parceiro()
        {          
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            parceiro = repositorioParceiro.SelecionarPorId(parceiro.Id);

            parceiro.Nome = "Parceiro Teste";

            repositorioParceiro.Editar(parceiro);

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_excluir_parceiro_existente()
        {       
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            parceiro = repositorioParceiro.SelecionarPorId(parceiro.Id);

            repositorioParceiro.Excluir(parceiro);

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();

        }

        [TestMethod]
        public void Deve_buscar_por_nome()
        {          
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            repositorioParceiro.BuscarPorNome(parceiro.Nome).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_listar_todos_parceiros()
        {           
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            var parceiro2 = Builder<Parceiro>.CreateNew().Persist();

            var listagem = repositorioParceiro.SelecionarTodos();

            listagem.Should().ContainInOrder(parceiro, parceiro2);

            listagem.Should().HaveCount(2);


        }

        [TestMethod]
        public void Deve_buscar_por_id()
        {         
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }
    }
}
