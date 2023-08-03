using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.Infra.ModuloAluguel
{
    public class RepositorioAluguel : RepositorioBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Aluguel aluguel)
        {
            var aluguelEncontrado = registros.SingleOrDefault(x => x.Id == aluguel.Id);

            if (aluguelEncontrado == null || aluguelEncontrado.Id == aluguel.Id)
            {
                return true;
            }

            return false;
        }
    }
}
