using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System.Reflection.Metadata.Ecma335;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : Pessoa<Condutor>
    {
        public DateTime Validade { get; set; }
        public string Cnh { get; set; } 
        public Cliente Cliente { get; set; }
        public bool EstaValido { get => Validade.Date > DateTime.Now.Date; }

        public Condutor() { }
        public Condutor(Guid id, string nome, string email, string telefone, string documento, DateTime validade, string cnh, Cliente cliente) : this()
        {
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            base.Id = id;
            this.Validade = validade;
            this.Cnh = cnh;
            this.Cliente = cliente;
        }
        public Condutor(string nome, string email, string telefone, string documento, DateTime validade, string cnh, Cliente cliente) : this()
        {
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            this.Validade = validade;
            this.Cnh = cnh;
            this.Cliente = cliente;
        }

    }
}
