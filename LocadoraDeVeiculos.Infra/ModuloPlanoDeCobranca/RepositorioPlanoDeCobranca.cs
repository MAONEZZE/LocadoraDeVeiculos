using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobranca : RepositorioBase<PlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobranca(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(PlanoDeCobranca planoCobranca)
        {
            var encontrado = registros.SingleOrDefault(x => x.Equals(planoCobranca));

            if (encontrado == null || encontrado.Id == planoCobranca.Id)
                return true;

            return false;
        }

        public List<PlanoDeCobranca> SelecionarPlanoDeCobrancaPorGrupoAutomovel(GrupoAutomovel grupoAutomovel)
        {
            return registros.Where(x => x.GrupoAutomovel == grupoAutomovel).ToList();
        }
    }
}
