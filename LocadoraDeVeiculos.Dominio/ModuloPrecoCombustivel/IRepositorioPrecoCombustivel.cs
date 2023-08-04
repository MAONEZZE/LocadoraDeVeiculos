namespace LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel
{
    public interface IRepositorioPrecoCombustivel
    {
        void Atualizar(PrecoCombustivel configuracaoDesconto);
        PrecoCombustivel Buscar();
    }
}
