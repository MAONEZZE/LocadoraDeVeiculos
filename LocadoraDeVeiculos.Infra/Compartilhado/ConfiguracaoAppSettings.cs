using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public class ConfiguracaoAppSettings
    {
        IConfiguration configuration;

        public ConfiguracaoAppSettings()
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
        }

        public string ObterConnectionString()
        {
            return configuration.GetConnectionString("SqlServer")!;
        }
        public string ObterArquivoJsonPrecoCombustivel()
        {
            return configuration.GetSection("ArquivoJson:ConfiguracaoPreco").Value!;
        }
    }
}
