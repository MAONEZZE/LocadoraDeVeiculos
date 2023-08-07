using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using Microsoft.Data.SqlClient;

namespace LocadoraDeVeiculos.TestesIntegracao
{
    public class RepositorioBaseTests
    {
        protected IRepositorioParceiro repositorioParceiro;

        protected IRepositorioCupom repositorioCupom;

       private ConfiguracaoAppSettings configuracao;

        public RepositorioBaseTests()
        {
            var configuracaoDb = new ConfiguracaoDb();

            configuracao = new ConfiguracaoAppSettings();

            var dbContext = configuracaoDb.InicializarContexto(configuracao);

            repositorioParceiro = new RepositorioParceiro(dbContext);

            repositorioCupom = new RepositorioCupom(dbContext);



            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);

            LimparTabelas();
        }

        protected void LimparTabelas()
        {
            string? connectionString = configuracao.ObterConnectionString(); 

            var sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBCUPOM];";

            var comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

    }

   
}
