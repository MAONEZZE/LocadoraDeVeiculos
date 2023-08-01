using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Infra.ModuloAutomovel
{
    public class RepositorioAutomovel : RepositorioBase<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Automovel automovel)
        {
            var encontrado = registros.SingleOrDefault(x => x.Placa == automovel.Placa)!;

            if (encontrado == null || encontrado.Id == automovel.Id)
                return true;

            return false;
        }
    }
}
