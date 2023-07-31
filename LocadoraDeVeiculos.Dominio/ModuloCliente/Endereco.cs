using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco()
        {
            
        }
        public Endereco(string logradouro, string bairro, string cidade, string estado, string cep, int numero, string complemento) : this()
        {
            this.Logradouro = logradouro;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Cep = cep;
            this.Numero = numero;
            this.Complemento = complemento;
        }
    }
}
