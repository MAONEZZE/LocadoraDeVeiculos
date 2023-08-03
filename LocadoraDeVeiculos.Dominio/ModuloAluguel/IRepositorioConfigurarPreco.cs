using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IRepositorioPrecoCombustivel
    {
        void GravarConfiguracoesCombustivel(PrecoCombustivel configuracaoDesconto);
        PrecoCombustivel ObterConfiguracaoDeCombustivel();
    }
}
