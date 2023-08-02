namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        public bool EhValido(Cliente cliente);
    }
}
