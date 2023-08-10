
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorioBase<Automovel>
    {
        bool EhValido(Automovel automovel);

        List<Automovel> SelecionarPorGrupoAutomovel(GrupoAutomovel grupoAutomovel);
    }
}
