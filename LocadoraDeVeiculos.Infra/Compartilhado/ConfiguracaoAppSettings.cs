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

        public string ObterCredencial()
        {
            var foo = Convert.FromBase64String(configuration.GetSection("Id:Id1").Value!);

            return System.Text.Encoding.UTF8.GetString(foo);
        }
    }
}
