using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Servico.ModuloAluguel;
using Moq;

namespace LocadoraDeVeiculos.TestesUnitarios._1___Aplicacao.ModuloAluguel
{
    [TestClass]
    public class ServicoAluguelTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMock;

        Mock<IRepositorioCliente> repositorioClienteMock;

        Mock<IRepositorioCondutor> repositorioCondutorMock;

        Mock<IRepositorioGrupoAutomovel> repositorioGrupoAutomovel;

        Mock<IRepositorioAutomovel> repositorioAutomovelMoq;

        Mock<IRepositorioPlanoDeCobranca> repositorioPlanoDeCobrancaMoq;

        Mock<IRepositorioTaxaServico> repositorioTaxaServicoMock;

        Mock<IRepositorioAluguel> repositorioAluguelMoq;

        Mock<IRepositorioPrecoCombustivel> repositorioPrecoCombustivelMoq;

        Mock<IRepositorioCliente> repositorioClienteMoq;

        Mock<IRepositorioCupom> repositorioCupomMoq;

        Mock<IRepositorioTaxaServico> repositorioTaxaServicoMoq;

        Mock<IContextoPersistencia> contexto;

        IGeradorEmail geradorEmail;

        IGeradorPdf geradorPdf;

        ServicoAluguel servicoAluguel;

        Funcionario funcionario;

        Cliente cliente;

        Condutor condutor;

        GrupoAutomovel grupoAutomovel;

        Automovel automovel;

        PlanoDeCobranca planoDeCobranca;

        Cupom cupom;

        TaxaServico taxaServico;

        Aluguel aluguel;



        public ServicoAluguelTest()
        {
            this.repositorioFuncionarioMock = new();
            this.repositorioClienteMock = new();
            this.repositorioCondutorMock = new();
            this.repositorioGrupoAutomovel = new();
            this.repositorioAutomovelMoq = new();
            this.repositorioPlanoDeCobrancaMoq = new();
            this.repositorioTaxaServicoMock = new();
            this.repositorioAluguelMoq = new();
            this.repositorioPrecoCombustivelMoq = new();
            this.repositorioClienteMoq = new();
            this.repositorioCupomMoq = new();
            this.repositorioTaxaServicoMoq = new();
            
            contexto = new();
            servicoAluguel = new(repositorioAluguelMoq.Object, repositorioPrecoCombustivelMoq.Object, repositorioPlanoDeCobrancaMoq.Object, repositorioAutomovelMoq.Object, repositorioClienteMoq.Object, geradorEmail, geradorPdf, contexto.Object);
            
            
            funcionario = new Funcionario("Fulano", DateTime.Now.AddDays(-7), 1000);

            repositorioFuncionarioMock.Setup(x => x.SelecionarPorId(funcionario.Id)).Returns(funcionario);

            Endereco endereco = new Endereco("Rua dos bobos","Bairro dos bobos", "Cidade dos bobos", "Estado dos bobos", "88501250", 0, "Complemento dos bobos");
            cliente = new Cliente("Ciclano","ciclano@gmail.com","999999999",TipoClienteEnum.CPF, endereco, "123456789");

            condutor = new  Condutor(cliente.Nome, cliente.Email, cliente.Telefone, cliente.Documento, DateTime.Now.AddDays(7), "12345678910", cliente);

            grupoAutomovel = new GrupoAutomovel
                            {
                                Nome = "Passeio",
                            };

            //automovel = new Automovel("ABC1234", "Fiat", "Uno", 2010, "Vermelho", 100, 5, 4, 4, 4, 4, 4, 4, 4, 4, grupoAutomovel);

        }
        [TestMethod]

        public void Deve_Inserir_Aluguel_Caso_Valido()
        {
            //arrange

        }
    }
}
