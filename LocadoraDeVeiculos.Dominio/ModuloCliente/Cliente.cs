using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : Pessoa<Cliente>
    {
        public List<Cupom> cuponsUtilizados;
        public Endereco Endereco { get; set; }

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
            this.Endereco = endereco;
        }
        public Cliente(Guid id, string nome, string email, string telefone, Endereco endereco, TipoClienteEnum tipoCliente, string documento) : this()
        {
            base.Id = id;
            base.Nome = nome;
            base.Documento = documento;
            base.Email = email;
            base.Telefone = telefone;
            base.TipoCliente = tipoCliente;
            this.Endereco = endereco;
        }
    }
}
