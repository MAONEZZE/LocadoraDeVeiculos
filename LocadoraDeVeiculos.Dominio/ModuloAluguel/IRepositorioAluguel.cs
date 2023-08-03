using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        bool EhValido(Aluguel aluguel);
    }
}
