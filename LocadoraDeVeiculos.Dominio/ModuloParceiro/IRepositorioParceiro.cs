using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorioBase<Parceiro>
    {
        Parceiro BuscarPorNome(string nome);

        bool EhValido(Parceiro parceiro);
    }
}
