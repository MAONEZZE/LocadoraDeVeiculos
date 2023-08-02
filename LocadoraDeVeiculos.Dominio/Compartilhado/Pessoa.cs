using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class Pessoa<T> : EntidadeBase<T>
        where T : EntidadeBase<T>
    {
        public string Documento { get; set; }
        public string Nome {  get; set; }
        public string Email { get; set; } 
        public string Telefone { get; set; }

        public override void AlterarInformacoes(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
