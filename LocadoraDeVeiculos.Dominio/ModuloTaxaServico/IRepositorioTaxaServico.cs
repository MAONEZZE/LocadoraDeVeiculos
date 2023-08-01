using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public interface IRepositorioTaxaServico : IRepositorioBase<TaxaServico>
    {
        TaxaServico BuscarPorNome(string nome);

        bool EhValido(TaxaServico taxaServico);
    }
}
