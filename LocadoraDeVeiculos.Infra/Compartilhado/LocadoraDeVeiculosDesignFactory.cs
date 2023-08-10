using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    internal class LocadoraDeVeiculosDesignFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadoraDeVeiculosDbContext(optionsBuilder.Options);
        }
    }

}

