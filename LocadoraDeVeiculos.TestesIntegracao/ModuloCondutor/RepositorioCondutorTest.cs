using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTest : RepositorioBaseTests
    {
        private Cliente cliente;

        public RepositorioCondutorTest() : base()
        {
            var endereco = new Endereco("rua", "bairro", "cidade", "estado", "cep", 0, "casa");

            cliente = Builder<Cliente>.CreateNew().With(c=>c.Endereco = endereco).Persist();
        }

        [TestMethod]
        public void DeveInserir_Condutor()
        {
            var condutor = Builder<Condutor>.CreateNew().With(c=>c.Cliente = cliente).Build();
        
            repositorioCondutor.Inserir(condutor);

            dbContext.SaveChanges();

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().Be(condutor);
        }   
    }
}
