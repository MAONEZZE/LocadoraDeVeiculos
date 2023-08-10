namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public class ConfiguracaoDb
    {
        public LocadoraDeVeiculosDbContext InicializarContexto(ConfiguracaoAppSettings configuracao)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(configuracao.ObterConnectionString());

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            AtualizarBancoDados(dbContext);

            return dbContext;
        }


        private void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();
            }
        }
    }
}
