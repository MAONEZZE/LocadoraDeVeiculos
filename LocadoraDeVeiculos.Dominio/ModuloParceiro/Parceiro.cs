using LocadoraDeVeiculos.Dominio.Compartilhado;
namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public string Nome { get; set; }

        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public override void AlterarInformacoes(Parceiro entidade)
        {
            Nome = entidade.Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Parceiro parceiro
                  && Id == parceiro.Id
                  && Nome == parceiro.Nome;
        }
    }
}
