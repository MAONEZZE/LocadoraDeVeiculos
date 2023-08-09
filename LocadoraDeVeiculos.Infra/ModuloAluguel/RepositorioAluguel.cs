using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;

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

        public override List<Aluguel> SelecionarTodos()
        {
            return registros.Include(x => x.Funcionario)
                            .Include(x => x.Cliente)
                            .Include(x => x.Condutor)
                            .Include(x => x.GrupoAutomovel)
                            .Include(x => x.Automovel)
                            .Include(x => x.PlanoDeCobranca)
                            .Include(x => x.Cupom)
                            .Include(x => x.TaxasServicos)
                            .ToList();
        }
    }
}
