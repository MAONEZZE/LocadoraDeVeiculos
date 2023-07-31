using LocadoraDeVeiculos.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        bool EhValido(Cliente cliente);
    }
}
