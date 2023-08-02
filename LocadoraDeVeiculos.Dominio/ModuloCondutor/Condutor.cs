using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : Pessoa<Condutor>
    {
        public DateTime Validade { get; set; }
        public string Cnh { get; set; } 
        public Cliente Cliente { get; set; }

        public Condutor(Guid id, DateTime validade, string cnh, Cliente cliente) 
        {
            base.Id = id;
            this.Validade = validade;
            this.Cnh = cnh;
            this.Cliente = cliente;
        }
        public Condutor(DateTime validade, string cnh, Cliente cliente)
        {
            this.Validade = validade;
            this.Cnh = cnh;
            this.Cliente = cliente;
        }

    }
}
