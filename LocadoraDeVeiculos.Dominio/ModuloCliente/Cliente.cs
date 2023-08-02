using LocadoraDeVeiculos.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : Pessoa<Cliente>
    {
        public List<Cupom> cuponsUtilizados;
        public TipoClienteEnum TipoCliente { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente()
        {
            this.cuponsUtilizados = new List<Cupom>();
            this.Endereco = new Endereco();
        }
        public Cliente(string nome, string email, string telefone, TipoClienteEnum tipoCliente, Endereco endereco, string documento) : this()
        {
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            this.TipoCliente = tipoCliente;
            this.Endereco = endereco;
        }
        public Cliente(Guid id, string nome, string email, string telefone, TipoClienteEnum tipoCliente, Endereco endereco, string documento) : this()
        {
            base.Id = id;
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            this.TipoCliente = tipoCliente;
            this.Endereco = endereco;
        }
    }
}
