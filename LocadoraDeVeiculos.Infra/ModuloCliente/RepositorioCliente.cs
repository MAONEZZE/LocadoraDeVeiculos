using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Cliente cliente)
        {

            var encontrado = registros.SingleOrDefault(x => x.tipoDocumento == cliente.tipoDocumento);

            if (encontrado == null || encontrado.Id == cliente.Id)
                return true;

            return false;
        }
    }
}
