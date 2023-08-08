using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloParceiro;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using Microsoft.Data.SqlClient;

namespace LocadoraDeVeiculos.TestesIntegracao.Compartilhado
{
    public class RepositorioBaseTests
    {
        #region Declaração dos repositórios
        protected IRepositorioParceiro repositorioParceiro;

        protected IRepositorioCupom repositorioCupom;

        protected IRepositorioCondutor repositorioCondutor;

        protected IRepositorioCliente repositorioCliente;

        protected IRepositorioPlanoDeCobranca repositorioPlano;
        #endregion

        private ConfiguracaoAppSettings configuracao;

        public RepositorioBaseTests()
        {
            var configuracaoDb = new ConfiguracaoDb();

            configuracao = new ConfiguracaoAppSettings();

            var dbContext = configuracaoDb.InicializarContexto(configuracao);

            #region Configuração dos repositorios
            repositorioParceiro = new RepositorioParceiro(dbContext);

            repositorioCupom = new RepositorioCupom(dbContext);

            repositorioCondutor = new RepositorioCondutor(dbContext);

            repositorioCliente = new RepositorioCliente(dbContext);

            repositorioPlano = new RepositorioPlanoDeCobranca(dbContext);

            #endregion

            #region Configuração do Builder
            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<PlanoDeCobranca>(repositorioPlano.Inserir);
            #endregion

            LimparTabelas();
        }

        protected void LimparTabelas()
        {
            string? connectionString = configuracao.ObterConnectionString();

            var sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBCUPOM];
                DELETE FROM [DBO].[TBCONDUTOR];
                DELETE FROM [DBO].[TBCLIENTE];
                DELETE FROM [DBO].[TBPLANODECOBRANCA];";

            var comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

    }


}
