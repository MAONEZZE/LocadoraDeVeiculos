
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using FluentResults.Extensions.FluentAssertions;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.TestesUnitarios._1___Aplicacao
{
    [TestClass]
    public class ServicoParceiroTestes
    {
        Mock<IRepositorioParceiro> repositorioMoq;

        ServicoParceiro servicoParceiro;

        Mock<IValidadorParceiro> validadorMock;

        Mock<IContextoPersistencia> contexto;

        Parceiro parceiro;
        public ServicoParceiroTestes()
        {
            validadorMock = new Mock<IValidadorParceiro>();
            repositorioMoq = new Mock<IRepositorioParceiro>();
            contexto = new Mock<IContextoPersistencia>();
            servicoParceiro = new ServicoParceiro(repositorioMoq.Object, contexto.Object);
            parceiro = new Parceiro("nome parceiro");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ele_seja_valido()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                .Returns(true);

            var result = servicoParceiro.Inserir(parceiro);

            result.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Once);
        }

        [TestMethod]
        public void Nao_deve_cadastrar_parceiro_caso_nome_tenha_caracteres()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                 .Returns(true);

            var parceiro = new Parceiro("@@@@@@");

            var resultado = servicoParceiro.Inserir(parceiro);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"'Nome' deve ser composto por letras e números.");

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_nome_seja_menor_3_letras()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                 .Returns(true);

            var parceiro = new Parceiro("abc");

            var resultado = servicoParceiro.Inserir(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_ele_nao_seja_valido()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                .Returns(false);

            var resultado = servicoParceiro.Inserir(parceiro);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_nome_nao_seja_valido()
        {
            validadorMock.Setup(i => i.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            var resultado = servicoParceiro.Inserir(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Never);
        }


        [TestMethod]
        public void Deve_editar_parceiro_caso_ele_seja_valido()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                .Returns(true);

            var result = servicoParceiro.Editar(parceiro);

            result.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Editar(parceiro), Times.Once);
        }

        [TestMethod]
        public void Deve_editar_parceiro_com_mesmo_nome()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                .Returns(true);

            var result = servicoParceiro.Editar(parceiro);

            result.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Editar(parceiro), Times.Once);

        }


        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_ele_nao_seja_valido()
        {
            validadorMock.Setup(i => i.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            var resultado = servicoParceiro.Editar(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Editar(parceiro), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_nome_tenha_caracteres()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                 .Returns(true);

            var parceiro = new Parceiro("@@@@@@");

            var resultado = servicoParceiro.Editar(parceiro);

            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"'Nome' deve ser composto por letras e números.");

            repositorioMoq.Verify(x => x.Editar(parceiro), Times.Never);
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_nome_seja_menor_3_letras()
        {
            repositorioMoq.Setup(x => x.EhValido(It.IsAny<Parceiro>()))
                 .Returns(true);

            var parceiro = new Parceiro("@@@");

            var resultado = servicoParceiro.Editar(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Editar(parceiro), Times.Never);
        }

        [TestMethod]
        public void Deve_excluir_parceiro_cadastrado()
        {
            repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>()))
                .Returns(true);

            var resultado = servicoParceiro.Excluir(parceiro);

            resultado.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Excluir(parceiro), Times.Once);
        }


        [TestMethod]
        public void Nao_Deve_excluir_parceiro_Nao_cadastrado()
        {
            repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>()))
                .Returns(false);

            var resultado = servicoParceiro.Excluir(parceiro);

            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Excluir(parceiro), Times.Never);

        }
    }

}
