using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Infra.ModuloCupom
{
    public class RepositorioCupom : RepositorioBase<Cupom>, IRepositorioCupom
    {
        public RepositorioCupom(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
