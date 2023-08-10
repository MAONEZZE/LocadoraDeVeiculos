using FluentResults.Extensions.FluentAssertions;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;

namespace LocadoraDeVeiculos.TestesUnitarios._1___Aplicacao
{
    [TestClass]
    public class ServicoFuncionarioTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;

        Mock<IRepositorioAluguel> repositorioAluguelMoq;

        Mock<IValidadorFuncionario> validadorMock;

        Mock<IContextoPersistencia> dbContext;

        private ServicoFuncionario servicoFuncionario;

        Mock<IContextoPersistencia> contexto;

        Funcionario funcionario;

        public ServicoFuncionarioTest()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            repositorioAluguelMoq = new Mock<IRepositorioAluguel>();
            validadorMock = new Mock<IValidadorFuncionario>();
            contexto = new Mock<IContextoPersistencia>();
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, repositorioAluguelMoq.Object, contexto.Object);
            funcionario = new Funcionario("Fulano", DateTime.Now.AddDays(-7), 1200);
        }

        #region Inserir
        [TestMethod]
        public void Deve_Inserir_Funcionario_Caso_Valido()
        {
            repositorioFuncionarioMoq.Setup(x => x.EhValido(It.IsAny<Funcionario>())).Returns(true);

            var resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once);

        }

        [TestMethod]
        public void Nao_Deve_Inserir_Funcionario_Caso_Nome_Tenha_Menos_De_3_Caracteres()
        {
            repositorioFuncionarioMoq.Setup(x => x.EhValido(It.IsAny<Funcionario>())).Returns(false);

            Funcionario funcionario = new Funcionario();

            var resultado = servicoFuncionario.Inserir(funcionario);

            resultado.Should().BeFailure();

            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never);
        }

        #endregion Inserir
    }
}

