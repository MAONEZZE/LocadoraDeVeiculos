namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorioBase<Cupom>
    {
        public bool EhValido(Cupom cupom);
    }
}
