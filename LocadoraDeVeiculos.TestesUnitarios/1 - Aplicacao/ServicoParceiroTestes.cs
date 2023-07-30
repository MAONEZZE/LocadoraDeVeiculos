
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using FluentResults.Extensions.FluentAssertions;
using FluentAssertions;

using FluentValidation.Results;
using Moq;


namespace LocadoraDeVeiculos.TestesUnitarios._1___Aplicacao
{
    [TestClass]
    public class ServicoParceiroTestes
    {
        Mock<IRepositorioParceiro> repositorioMoq;

        ServicoParceiro servicoParceiro;

        Mock<IValidadorParceiro> validadorMock;

        Parceiro parceiro;
        public ServicoParceiroTestes()
        {

            validadorMock = new Mock<IValidadorParceiro>();
            repositorioMoq = new Mock<IRepositorioParceiro>();
            servicoParceiro = new ServicoParceiro(repositorioMoq.Object);
            parceiro = new Parceiro("nome parceiro");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ele_seja_valido()
        {

            var result = servicoParceiro.Inserir(parceiro);

            result.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Once);
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_nome_nao_seja_valido()
        {
            validadorMock.Setup(i => i.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais");
                    return resultado;
                });

            var resultado = servicoParceiro.Inserir(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Never);
        }
    }

}
