using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using LocadoraDeVeiculos.WinApp.ModuloParceiro;
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
            var dbContext = InicializarContexto();

            AtualizarBancoDados(dbContext);

            var repositorioParceiro = new RepositorioParceiro(dbContext);

            var servicoParceiro = new ServicoParceiro(repositorioParceiro);

            var controladorParceiro = new ControladorParceiro(servicoParceiro,repositorioParceiro);

            var repositorioCupom = new RepositorioCupom(dbContext);

         
            controladores.Add("Parceiro", controladorParceiro);
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
