using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.Infra.ModuloTaxaServico;
using LocadoraDeVeiculos.Servico.ModuloAutomovel;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCupom;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloTaxaServico;
using LocadoraDeVeiculos.WinApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloConfiguracaoPreco;
using LocadoraDeVeiculos.WinApp.ModuloCupom;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.WinApp.ModuloParceiro;
using LocadoraDeVeiculos.WinApp.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public static class Ioc
    {
        public static bool Inicializar;

        static IDictionary<string, ControladorBase> controladores = new Dictionary<string, ControladorBase>();

        static Ioc()
        {
            var jsonString = ObterArquivoJsonPrecoCombustivel();

            var dbContext = InicializarContexto();

            AtualizarBancoDados(dbContext);

            var repositorioParceiro = new RepositorioParceiro(dbContext);

            var servicoParceiro = new ServicoParceiro(repositorioParceiro);

            var controladorParceiro = new ControladorParceiro(servicoParceiro, repositorioParceiro);

            var repositorioCupom = new RepositorioCupom(dbContext);

            var servicoCupom = new ServicoCupom(repositorioCupom);

            var controladorCupom = new ControladorCupom(servicoCupom, repositorioCupom, repositorioParceiro);

            var repositorioGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);

            var servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel);

            var controladorGrupoAutomovel = new ControladorGrupoAutomovel(servicoGrupoAutomovel, repositorioGrupoAutomovel);

            var repositorioAutomovel = new RepositorioAutomovel(dbContext);

            var servicoAutomovel = new ServicoAutomovel(repositorioAutomovel);

            var controladorAutomovel = new ControladorAutomovel(repositorioAutomovel, repositorioGrupoAutomovel, servicoAutomovel);

            var repositorioCliente = new RepositorioCliente(dbContext);

            var servicoCliente = new ServicoCliente(repositorioCliente);

            var controladorCliente = new ControladorCliente(repositorioCliente, servicoCliente);

            var repositorioTaxaServico = new RepositorioTaxaServico(dbContext);

            var servicoTaxaServico = new ServicoTaxaServico(repositorioTaxaServico);

            var controladorTaxaServico = new ControladorTaxaServico(servicoTaxaServico, repositorioTaxaServico);

            var repositorioFuncionario = new RepositorioFuncionario(dbContext);

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);

            var controladorFuncionario = new ControladorFuncionario(servicoFuncionario, repositorioFuncionario);

           var repPrecoComb = new RepositorioPrecoCombustivel(jsonString);


            controladores.Add("Parceiro", controladorParceiro);
            controladores.Add("Cupom", controladorCupom);
            controladores.Add("Categoria", controladorGrupoAutomovel);
            controladores.Add("Veículo", controladorAutomovel);
            controladores.Add("Cliente", controladorCliente);
            controladores.Add("Taxas ou Serviços", controladorTaxaServico);
            controladores.Add("Funcionário", controladorFuncionario);
        }

        public static ControladorBase ObterControlador(object sender)
        {
            ToolStripMenuItem control = (ToolStripMenuItem)sender;

            return controladores[control.Text];
        }

        private static LocadoraDeVeiculosDbContext InicializarContexto()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(ObterConnectionString());

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            AtualizarBancoDados(dbContext);

            return dbContext;
        }

        private static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            return configuracao.GetConnectionString("SqlServer")!;
        }

        private static string ObterArquivoJsonPrecoCombustivel()
        {
            var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            return configuracao["ArquivoJson:ConfiguracaoPreco"]!;
        }



        private static void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();
            }
        }
    }
}
