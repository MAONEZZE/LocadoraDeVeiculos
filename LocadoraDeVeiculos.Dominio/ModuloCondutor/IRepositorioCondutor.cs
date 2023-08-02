namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorioBase<Condutor>
    {
        public bool EhValido(Condutor condutor);
    }
}
