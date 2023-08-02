
namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorioBase<Automovel>
    {
        bool EhValido(Automovel automovel);

        bool EstaDisponivel(Automovel automovel);
    }
}
