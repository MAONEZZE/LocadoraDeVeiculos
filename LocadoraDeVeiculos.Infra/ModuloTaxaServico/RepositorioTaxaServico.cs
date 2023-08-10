using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Infra.ModuloTaxaServico
{
    public class RepositorioTaxaServico : RepositorioBase<TaxaServico>, IRepositorioTaxaServico
    {
        public RepositorioTaxaServico(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public TaxaServico BuscarPorNome(string nome)
        {
            return registros.SingleOrDefault(p => p.Nome == nome)!;
        }

        public bool EhValido(TaxaServico taxaServico)
        {
            var encontrado = BuscarPorNome(taxaServico.Nome);

           if(encontrado == null || encontrado.Id == taxaServico.Id)
                return true;

            return false;
        }
    }
}
