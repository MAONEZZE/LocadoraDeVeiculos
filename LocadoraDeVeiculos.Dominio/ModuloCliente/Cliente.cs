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
        public Endereco endereco;

        public Cliente()
        {
            this.cuponsUtilizados = new List<Cupom>();
        }
        public Cliente(string nome, string email, string telefone, Endereco endereco, TipoClienteEnum tipoCliente, string documento) : this()
        {
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            base.TipoCliente = tipoCliente;
            this.endereco = endereco;
        }
        public Cliente(int id, string nome, string email, string telefone, Endereco endereco, TipoClienteEnum tipoCliente, string documento) : this()
        {
            base.Id = id;
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            base.TipoCliente = tipoCliente;
            this.endereco = endereco;
        }
    }
}
