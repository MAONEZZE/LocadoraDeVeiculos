using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.TestesIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioTest : RepositorioBaseTests
    {
        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Build();

            repositorioFuncionario.Inserir(funcionario);

            dbContext.SaveChanges();

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Persist();

            funcionario = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            funcionario.Nome = "Nome Editado";

            repositorioFuncionario.Editar(funcionario);

            dbContext.SaveChanges();

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }

        [TestMethod]

        public void Deve_excluir_funcionario()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Persist();

            funcionario = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            repositorioFuncionario.Excluir(funcionario);

            dbContext.SaveChanges();

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }
        [TestMethod]
        public void Deve_buscar_por_nome()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.BuscarPorNome(funcionario.Nome).Should().Be(funcionario);
        }

        [TestMethod]
        public void Deve_listar_todos_os_funcionarios()
        {
            Funcionario funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.SelecionarTodos().Should().HaveCount(1);
        }
    }
}
