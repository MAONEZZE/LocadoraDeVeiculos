using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
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

            var arquivoConfiguracao = configuracao.GetSection("ArquivoJson:ConfiguracaoPreco").Value!;

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

            servicos.AddTransient<ControladorCliente>();
            servicos.AddTransient<ServicoCliente>();
            servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
            servicos.AddTransient<IRepositorioCliente, RepositorioCliente>();

            servicos.AddTransient<ControladorCondutor>();
            servicos.AddTransient<ServicoCondutor>();
            servicos.AddTransient<IValidadorCondutor, ValidadorCondutor>();
            servicos.AddTransient<IRepositorioCondutor, RepositorioCondutor>();

            servicos.AddTransient<ControladorPlanoDeCobranca>();
            servicos.AddTransient<ServicoPlanoDeCobranca>();
            servicos.AddTransient<IValidadorPlanoDeCobranca, ValidadorPlanoDeCobranca>();
            servicos.AddTransient<IRepositorioPlanoDeCobranca, RepositorioPlanoDeCobranca>();

            servicos.AddTransient <ControladorAluguel>();
            servicos.AddTransient <ServicoAluguel>();
            servicos.AddTransient <IValidadorAluguel, ValidadorAluguel>();
            servicos.AddTransient <IRepositorioAluguel, RepositorioAluguel>();

            servicos.AddTransient<ControladorAutomovel>();
            servicos.AddTransient<ServicoAutomovel>();
            servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddTransient<IRepositorioAutomovel, RepositorioAutomovel>();

            servicos.AddTransient<ControladorTaxaServico>();
            servicos.AddTransient<ServicoTaxaServico>();
            servicos.AddTransient<IValidadorTaxaServico, ValidadorTaxaServico>();
            servicos.AddTransient<IRepositorioTaxaServico, RepositorioTaxaServico>();

            servicos.AddTransient<ControladorFuncionario>();
            servicos.AddTransient<ServicoFuncionario>();
            servicos.AddTransient<IValidadorFuncionario, ValidadorFuncionario>();
            servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionario>();

            servicos.AddTransient<IRepositorioPrecoCombustivel, RepositorioPrecoCombustivel>();

            servicos.AddTransient<ControladorGrupoAutomovel>();
            servicos.AddTransient<ServicoGrupoAutomovel>();
            servicos.AddTransient<IValidadorGrupoAutomovel, ValidadorGrupoAutomovel>();
            servicos.AddTransient<IRepositorioGrupoAutomovel, RepositorioGrupoAutomovel>();

            servicos.AddTransient<IGeradorEmail, GeradorEmail>();
            servicos.AddTransient<IGeradorPdf, GeradorPdf>();
            servicos.AddTransient<ISerializador, SerializadorJson>(s => new SerializadorJson(arquivoConfiguracao));

            container = servicos.BuildServiceProvider();
        
            AtualizarBanco(container);
        }


        public T Get<T>()
        {
            return container.GetService<T>()!;
        }

        public static void AtualizarBanco(ServiceProvider container)
        {
            using (var scope = container.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LocadoraDeVeiculosDbContext>();

                var migracoesPendentes = dbContext.Database.GetPendingMigrations();

                if (migracoesPendentes.Any())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}

