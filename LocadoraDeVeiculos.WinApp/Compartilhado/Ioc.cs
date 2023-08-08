using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.InfraEmail;
using LocadoraDeVeiculos.Servico.ModuloCupom;
using LocadoraDeVeiculos.Servico.ModuloParceiro;
using LocadoraDeVeiculos.WinApp.ModuloCupom;
using LocadoraDeVeiculos.WinApp.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public class Ioc : IIoc
    {
        private ServiceProvider container;

        public Ioc()
        {
            var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, LocadoraDeVeiculosDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            servicos.AddTransient<ControladorParceiro>();
            servicos.AddTransient<ServicoParceiro>();
            servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
            servicos.AddTransient<IRepositorioParceiro, RepositorioParceiro>();

            servicos.AddTransient<ControladorCupom>();
            servicos.AddTransient<ServicoCupom>();
            servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
            servicos.AddTransient<IRepositorioCupom, RepositorioCupom>();



          

            servicos.AddTransient<IGeradorEmail, GeradorEmail>();
            servicos.AddTransient<IGeradorPdf, GeradorPdf>();


            container = servicos.BuildServiceProvider();
        }


        public T Get<T>()
        {
            return container.GetService<T>()!;
        }
    }
}
