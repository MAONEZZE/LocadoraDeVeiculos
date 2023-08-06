using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloAluguel;
using LocadoraDeVeiculos.Infra.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.PrecosCombustiveis.ModuloPrecoCombustivel;
using LocadoraDeVeiculos.InfraEmail;
using LocadoraDeVeiculos.Servico.ModuloAluguel;
using LocadoraDeVeiculos.Servico.ModuloAutomovel;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloCupom;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloTaxaServico;
using LocadoraDeVeiculos.WinApp.ModuloAluguel;
using LocadoraDeVeiculos.WinApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloCupom;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloParceiro;
using LocadoraDeVeiculos.WinApp.ModuloTaxaServico;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class Ioc
    {
        public static bool Inicializar;

        static IDictionary<string, ControladorBase> controladores = new Dictionary<string, ControladorBase>();

        static Ioc()
        {
           var configuracao = new ConfiguracaoAppSettings();

            var configuracaoDb = new ConfiguracaoDb();

            var dbContext = configuracaoDb.InicializarContexto(configuracao);

            configuracaoDb.AtualizarBancoDados(dbContext);

            var repositorioParceiro = new RepositorioParceiro(dbContext);

            var servicoParceiro = new ServicoParceiro(repositorioParceiro);

            var controladorParceiro = new ControladorParceiro(servicoParceiro, repositorioParceiro);

            var repositorioCupom = new RepositorioCupom(dbContext);

            var servicoCupom = new ServicoCupom(repositorioCupom);

            var controladorCupom = new ControladorCupom(servicoCupom, repositorioCupom, repositorioParceiro);

            var repositorioGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);

            var repositorioAluguel = new RepositorioAluguel(dbContext);

            var repositorioAutomovel = new RepositorioAutomovel(dbContext);

            var servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel, repositorioAutomovel);

            var controladorGrupoAutomovel = new ControladorGrupoAutomovel(servicoGrupoAutomovel, repositorioGrupoAutomovel);

            var servicoAutomovel = new ServicoAutomovel(repositorioAutomovel, repositorioAluguel);

            var controladorAutomovel = new ControladorAutomovel(repositorioAutomovel, repositorioGrupoAutomovel, servicoAutomovel);

            var repositorioCliente = new RepositorioCliente(dbContext);

            var servicoCliente = new ServicoCliente(repositorioCliente);

            var controladorCliente = new ControladorCliente(repositorioCliente, servicoCliente);

            var repositorioCondutor = new RepositorioCondutor(dbContext);

            var servicoCondutor = new ServicoCondutor(repositorioCondutor);

            var controladorCondutor = new ControladorCondutor(repositorioCondutor, repositorioCliente, servicoCondutor);

            var repositorioTaxaServico = new RepositorioTaxaServico(dbContext);

            var servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServico);

            var controladorTaxaServico = new ControladorTaxaServico(servicoTaxaServico, repositorioTaxaServico);

            var repositorioFuncionario = new RepositorioFuncionario(dbContext);

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);

            var controladorFuncionario = new ControladorFuncionario(servicoFuncionario, repositorioFuncionario);

            var repPrecoComb = new RepositorioPrecoCombustivel(new SerializadorJson(configuracao.ObterArquivoJsonPrecoCombustivel()));

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobranca(dbContext);

            var geradorEmail = new GeradorEmail();

            var geradorPdf = new GeradorPdf();

            var servicoAluguel = new ServicoAluguel(repositorioAluguel, repPrecoComb, geradorEmail, geradorPdf);

            var controladorAluguel = new ControladorAluguel(servicoAluguel,
                                                            repositorioAluguel,
                                                            repositorioFuncionario,
                                                            repositorioCliente,
                                                            repositorioCondutor,
                                                            repositorioGrupoAutomovel,
                                                            repositorioAutomovel,
                                                            repositorioTaxaServico,
                                                            repositorioPlanoDeCobranca,
                                                            repositorioCupom
                                                            );


            controladores.Add("Parceiro", controladorParceiro);
            controladores.Add("Cupom", controladorCupom);
            controladores.Add("Categoria", controladorGrupoAutomovel);
            controladores.Add("Veículo", controladorAutomovel);
            controladores.Add("Cliente", controladorCliente);
            controladores.Add("Condutor", controladorCondutor);
            controladores.Add("Taxas ou Serviços", controladorTaxaServico);
            controladores.Add("Funcionário", controladorFuncionario);
            controladores.Add("Aluguel", controladorAluguel);
        }

        public static ControladorBase ObterControlador(object sender)
        {
            ToolStripMenuItem control = (ToolStripMenuItem)sender;

            return controladores[control.Text];
        }

      
    }
}
