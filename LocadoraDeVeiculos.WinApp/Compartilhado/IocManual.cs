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
using LocadoraDeVeiculos.Servico.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Servico.ModuloTaxaServico;
using LocadoraDeVeiculos.WinApp.ModuloAluguel;
using LocadoraDeVeiculos.WinApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloCupom;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloParceiro;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxaServico;


namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class IocManual
    {
        public static bool Inicializar;

        static IDictionary<string, ControladorBase> controladores = new Dictionary<string, ControladorBase>();

        static IocManual()
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

            var repPlano = new RepositorioPlanoDeCobranca(dbContext);

            #endregion

            #region serviços

            var servicoParceiro = new ServicoParceiro(repositorioParceiro,dbContext);

            var servicoCupom = new ServicoCupom(repositorioCupom,repositorioAluguel, dbContext);

            var servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel, repositorioAutomovel, dbContext);

            var servicoAutomovel = new ServicoAutomovel(repositorioAutomovel, repositorioAluguel, dbContext);

            var servicoCliente = new ServicoCliente(repositorioCliente, dbContext);

            var servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServico, repositorioAluguel, dbContext);

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, repositorioAluguel, dbContext);

            var servicoAluguel = new ServicoAluguel(repositorioAluguel, repPrecoComb, repositorioPlanoDeCobranca, repositorioAutomovel, repositorioCliente, geradorEmail, geradorPdf, dbContext);

            var servicoCondutor = new ServicoCondutor(repositorioCondutor, repositorioAluguel, dbContext);

            var servicoPlano = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca, dbContext);

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
                                                            servicoAutomovel,
                                                            servicoCondutor,
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

            var controladorPlano = new ControladorPlanoDeCobranca(repositorioPlanoDeCobranca, repositorioGrupoAutomovel, servicoPlano);

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
            controladores.Add("Plano de Cobrança", controladorPlano);

  
        }

        public static ControladorBase ObterControlador(object sender)
        {
            ToolStripMenuItem control = (ToolStripMenuItem)sender;

            return controladores[control.Text];
        }
     
    }
}
