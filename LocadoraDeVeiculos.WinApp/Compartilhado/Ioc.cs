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
            var geradorPdf = new GeradorPdf();

            var geradorEmail = new GeradorEmail();

            var configuracaoDb = new ConfiguracaoDb();

            var configuracao = new ConfiguracaoAppSettings();
        
            var dbContext = configuracaoDb.InicializarContexto(configuracao);


            #region repositórios

            var repositorioParceiro = new RepositorioParceiro(dbContext);

            var repositorioCupom = new RepositorioCupom(dbContext);

            var repositorioAluguel = new RepositorioAluguel(dbContext);

            var repositorioAutomovel = new RepositorioAutomovel(dbContext);

            var repositorioCliente = new RepositorioCliente(dbContext);

            var repositorioGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);

            var repositorioCondutor = new RepositorioCondutor(dbContext);

            var repositorioTaxaServico = new RepositorioTaxaServico(dbContext);

            var repositorioFuncionario = new RepositorioFuncionario(dbContext);

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobranca(dbContext);

            var repPrecoComb = new RepositorioPrecoCombustivel(new SerializadorJson(configuracao.ObterArquivoJsonPrecoCombustivel()));

            #endregion

            #region serviços
            var servicoParceiro = new ServicoParceiro(repositorioParceiro);

            var servicoCupom = new ServicoCupom(repositorioCupom);

            var servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel, repositorioAutomovel);

            var servicoAutomovel = new ServicoAutomovel(repositorioAutomovel, repositorioAluguel);

            var servicoCliente = new ServicoCliente(repositorioCliente);

            var servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServico);

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);

            var servicoAluguel = new ServicoAluguel(repositorioAluguel, repPrecoComb, geradorEmail, geradorPdf);

            var servicoCondutor = new ServicoCondutor(repositorioCondutor);

            #endregion

            #region controladores
            var controladorCupom = new ControladorCupom(servicoCupom, repositorioCupom, repositorioParceiro);

            var controladorParceiro = new ControladorParceiro(servicoParceiro, repositorioParceiro);

            var controladorGrupoAutomovel = new ControladorGrupoAutomovel(servicoGrupoAutomovel, repositorioGrupoAutomovel);      

            var controladorAutomovel = new ControladorAutomovel(repositorioAutomovel, repositorioGrupoAutomovel, servicoAutomovel);

            var controladorCliente = new ControladorCliente(repositorioCliente, servicoCliente);

            var controladorCondutor = new ControladorCondutor(repositorioCondutor, repositorioCliente, servicoCondutor);

            var controladorTaxaServico = new ControladorTaxaServico(servicoTaxaServico, repositorioTaxaServico);

            var controladorFuncionario = new ControladorFuncionario(servicoFuncionario, repositorioFuncionario);

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

            #endregion


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
