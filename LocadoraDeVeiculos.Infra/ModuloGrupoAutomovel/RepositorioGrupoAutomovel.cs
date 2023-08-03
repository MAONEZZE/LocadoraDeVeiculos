using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovel : RepositorioBase<GrupoAutomovel>, IRepositorioGrupoAutomovel
    {
        public RepositorioGrupoAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(GrupoAutomovel grupo)
        {
            var encontrado = registros.SingleOrDefault(x => x.Nome == grupo.Nome)!;

            if (encontrado == null || encontrado.Id == grupo.Id)
                return true;

            return false;
        }
    }
}
