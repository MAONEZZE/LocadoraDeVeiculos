using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using Microsoft.Data.SqlClient;

namespace LocadoraDeVeiculos.TestesIntegracao
{
    public class RepositorioBaseTests
    {
        protected IRepositorioParceiro repositorioParceiro;

        protected IRepositorioCupom repositorioCupom;

        protected IRepositorioCondutor repositorioCondutor;

        protected IRepositorioCliente repositorioCliente;

        protected IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        protected IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        private ConfiguracaoAppSettings configuracao;

        protected LocadoraDeVeiculosDbContext dbContext;

        public RepositorioBaseTests()
        {

            var configuracaoDb = new ConfiguracaoDb();

            configuracao = new ConfiguracaoAppSettings();

            dbContext = configuracaoDb.InicializarContexto(configuracao);

            repositorioParceiro = new RepositorioParceiro(dbContext);

            repositorioCupom = new RepositorioCupom(dbContext);

            repositorioCondutor = new RepositorioCondutor(dbContext);

            repositorioPlanoDeCobranca = new RepositorioPlanoDeCobranca(dbContext);

            repositorioCliente = new RepositorioCliente(dbContext);

            repositorioGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);

            LimparTabelas();

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>((p) =>
            {           
                repositorioParceiro.Inserir(p);
                dbContext.SaveChanges();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cupom>((c) =>
            {              
                repositorioCupom.Inserir(c);
                dbContext.SaveChanges();
            });

            BuilderSetup.SetCreatePersistenceMethod<Condutor>((c)=>
            {           
                repositorioCondutor.Inserir(c);
                dbContext.SaveChanges();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cliente>((c) =>
            {
                repositorioCliente.Inserir(c);
                dbContext.SaveChanges();
            });


            BuilderSetup.SetCreatePersistenceMethod<PlanoDeCobranca>((c) =>
            {
               repositorioPlanoDeCobranca.Inserir(c);
                dbContext.SaveChanges();
            });


            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>((c) =>
            {
                repositorioGrupoAutomovel.Inserir(c);
                dbContext.SaveChanges();
            });


        }

        protected void LimparTabelas()
        {
            string? connectionString = configuracao.ObterConnectionString();

            var sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBCUPOM];
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBCONDUTOR];
                DELETE FROM [DBO].[TBCLIENTE];
                DELETE FROM [DBO].[TBGrupoAutomovel];
                DELETE FROM [DBO].[TBPlanoDeCobranca];
                ";

            var comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

    }


}
