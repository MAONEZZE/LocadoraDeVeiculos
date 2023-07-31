using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase<TaxaServico>
    {
        public string Nome { get; set; }

        public int Preco { get; set; }

        public EnumTipoCalculo TipoCalculo { get; set; }

        public TaxaServico(int id, string nome, int preco, EnumTipoCalculo tipoCalculo)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            TipoCalculo = tipoCalculo;
        }

        public override void AlterarInformacoes(TaxaServico entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Preco = entidade.Preco;
            TipoCalculo = entidade.TipoCalculo;
        }

    }
}
