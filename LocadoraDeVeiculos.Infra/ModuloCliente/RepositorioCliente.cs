using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Cliente cliente)
        {

            var encontrado = registros.SingleOrDefault(x => x.Documento == cliente.Documento);

            if (encontrado == null || encontrado.Id == cliente.Id)
                return true;

            return false;
        }

        public override List<Cliente> SelecionarTodos()
        {
            return registros.Include(x => x.ListaCupons).ToList();
        }
    }
}
