using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Servico.ModuloTaxaServico;
using Moq;
using System;


namespace LocadoraDeVeiculos.TestesUnitarios._1___Aplicacao
{
    [TestClass]
    public class ServicoTaxaServicoTest
    {
        Mock<IRepositorioTaxaServico> repositorioTaxaServicoMoq;
        Mock<IValidadorTaxaServico> validadorMock;

        private ServicoTaxaServico servicoTaxaServico;

        TaxaServico taxaServico;

        Guid guidId;

        public ServicoTaxaServicoTest()
        {
            repositorioTaxaServicoMoq = new Mock<IRepositorioTaxaServico>();
            validadorMock = new Mock<IValidadorTaxaServico>();
            servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServicoMoq.Object);
            taxaServico = new TaxaServico("Limpeza", 10, EnumTipoCalculo.Diario);

             guidId = Guid.NewGuid();
        }
        #region Inserir
        [TestMethod]
        public void Deve_Inserir_TaxaServico_Caso_Valido()
        {
            //arrange
            taxaServico = new TaxaServico("Limpeza", 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            //assert
            resultado.Should().BeSuccess();

            repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Once);
        }
        [TestMethod]
        public void Nao_Deve_Inserir_TaxaServico_Caso_Invalido()
        {
            //arrange
            taxaServico = new TaxaServico("", 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Never);
        }
        [TestMethod]
        public void Nao_Deve_Inserir_TaxaServico_Caso_Tenha_Nome_Repetido()
        {
            //arrange
            string nomeTaxaServico = "Limpeza";
            repositorioTaxaServicoMoq.Setup(x => x.BuscarPorNome(nomeTaxaServico))
                .Returns(() =>
                {
                    return new TaxaServico(default, nomeTaxaServico, 10, EnumTipoCalculo.Diario);
                });

            //action
            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            //assert
            resultado.Should().BeFailure();

            resultado.Reasons[0].Message.Should().Be($"Já existe uma Taxa ou Serviço com o nome '{taxaServico.Nome}'");

            repositorioTaxaServicoMoq.Verify(x => x.Inserir(taxaServico), Times.Never);
        }
        [TestMethod]
        public void Deve_Tratar_Erros_Caso_Ocorra_Ao_Tentar_Inserir()
        {
            //arrange
            repositorioTaxaServicoMoq.Setup(x => x.Inserir(It.IsAny<TaxaServico>()))
                .Throws(new Exception());

            //action
            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Erro desconhecido. Falha ao tentar inserir Taxa ou Serviço.");

        }
        #endregion Inserir
        #region Editar
        [TestMethod]
        public void Deve_Editar_TaxaServico_Caso_Valido()
        {
          

            //arrange
            taxaServico = new TaxaServico(guidId, "Limpeza", 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Editar(taxaServico);

            //assert
            resultado.Should().BeSuccess();

            repositorioTaxaServicoMoq.Verify(x => x.Editar(taxaServico), Times.Once);
        }
        [TestMethod]
        public void Nao_Deve_Editar_TaxaServico_Caso_Invalido()
        {
            //arrange
            taxaServico = new TaxaServico(guidId, "", 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Editar(taxaServico);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxaServicoMoq.Verify(x => x.Editar(taxaServico), Times.Never);
        }
        [TestMethod]
        public void Deve_Editar_TaxaServico_Com_Mesmo_Nome()
        {
            //arrange
            string nomeTaxaServico = "Limpeza";
            int id = 1;
            repositorioTaxaServicoMoq.Setup(x => x.BuscarPorNome(nomeTaxaServico))
                .Returns(() =>
                {
                    return new TaxaServico(guidId, nomeTaxaServico, 10, EnumTipoCalculo.Diario);
                });

            TaxaServico outraTaxaServico = new(guidId, nomeTaxaServico, 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Editar(outraTaxaServico);

            //assert
            resultado.Should().BeSuccess();

            repositorioTaxaServicoMoq.Verify(x => x.Editar(outraTaxaServico), Times.Once);
        }
        [TestMethod]
        public void Nao_Deve_Editar_TaxaServico_Caso_Nome_Seja_Repetido()
        {
            //arrange
            string nomeTaxaServico = "Limpeza";

            repositorioTaxaServicoMoq.Setup(x => x.BuscarPorNome(nomeTaxaServico))
                .Returns(() =>
                {
                    return new TaxaServico(guidId, nomeTaxaServico, 10, EnumTipoCalculo.Diario);
                });

            var novoId = Guid.NewGuid();

            TaxaServico novoTaxaServico = new(novoId, nomeTaxaServico, 10, EnumTipoCalculo.Diario);

            //action
            Result resultado = servicoTaxaServico.Editar(novoTaxaServico);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxaServicoMoq.Verify(x => x.Editar(novoTaxaServico), Times.Never);
        }
        [TestMethod]
        public void Deve_Tratar_Erros_Caso_Ocorra_Ao_Tentar_Editar()
        {
            //arrange
            repositorioTaxaServicoMoq.Setup(x => x.Editar(It.IsAny<TaxaServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxaServico.Editar(taxaServico);

            //assert
            resultado.Should().BeFailure();

            resultado.Reasons[0].Message.Should().Be("Erro desconhecido. Falha ao tentar editar Taxa ou Serviço.");
        }
        #endregion Editar
        #region Excluir
        [TestMethod]
        public void Nao_Deve_Excluir_TaxaServico_Caso_Ela_Nao_Exista()
        {
            //arrange
            TaxaServico novataxaServico = new(guidId, "Limpeza", 10, EnumTipoCalculo.Diario);

            repositorioTaxaServicoMoq.Setup(x => x.Existe(novataxaServico))
                .Returns(() =>
                {
                    return false;
                });

            //action 
            Result resultado = servicoTaxaServico.Excluir(novataxaServico);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxaServicoMoq.Verify(x => x.Excluir(novataxaServico), Times.Never);
        }
        [TestMethod]
        public void Deve_Tratar_Erros_Caso_Ocorra_Ao_Tentar_Excluir()
        {
            //arrange
            taxaServico = new TaxaServico(guidId, "Limpeza", 10, EnumTipoCalculo.Diario);

            repositorioTaxaServicoMoq.Setup(x => x.Existe(taxaServico))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action

            Result resultado = servicoTaxaServico.Excluir(taxaServico);

            //assert
            resultado.Should().BeFailure();

            resultado.Reasons[0].Message.Should().Be("Erro desconhecido. Falha ao tentar excluir Taxa ou Serviço.");
        }
        #endregion Excluir
    }
}
