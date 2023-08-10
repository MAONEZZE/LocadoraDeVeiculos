
namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public interface IRepositorioGrupoAutomovel : IRepositorioBase<GrupoAutomovel>
    {
        bool EhValido(GrupoAutomovel grupo);
    }
}
