using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorioBase<Condutor>
    {
        public bool EhValido(Condutor condutor);

        List<Condutor> SelecionarPorCliente(Cliente cliente);
    }
}
