using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataValidade { get; set; }

        public Parceiro Parceiro { get; set; }

        public bool EhValido { get => DataValidade >= DateTime.Now.Date; }

        public Cupom() { }

        public Cupom(Guid id, string nome, decimal valor, DateTime dataValidade, Parceiro parceiro) : this(nome, valor, dataValidade, parceiro)
        {
            Id = id;
        }
        public Cupom(string nome, decimal valor, DateTime dataValidade, Parceiro parceiro)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
        }

        public override void AlterarInformacoes(Cupom entidade)
        {
            Nome = entidade.Nome;
            Valor = entidade.Valor;
            DataValidade = entidade.DataValidade;
            Parceiro = entidade.Parceiro;
        }

        public override string ToString()
        {
            return $"{Nome} - Parceiro: {Parceiro.Nome} - Validade: {DataValidade:d}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom &&
                   Id == cupom.Id &&
                   Nome == cupom.Nome &&
                   Valor == cupom.Valor &&
                   DataValidade.Date == cupom.DataValidade.Date &&
                   Parceiro == cupom.Parceiro &&
                   EhValido == cupom.EhValido;
        }
    }
}
