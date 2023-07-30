using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloParceiro
{
    public class RepositorioParceiro : RepositorioBase<Parceiro>, IRepositorioParceiro
    {
        public RepositorioParceiro(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Parceiro BuscarPorNome(string nome)
        {
            return registros.SingleOrDefault(p => p.Nome == nome)!;
        }

        public bool EhValido(Parceiro parceiro)
        {
            var encontrado = registros.SingleOrDefault(p => p.Nome == parceiro.Nome)!;

            if(encontrado == null || encontrado.Id == parceiro.Id)
                return true;

            return false;
        }
    }
}
