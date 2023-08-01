using SequentialGuid;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T> where T: EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = SequentialGuidGenerator.Instance.NewGuid();
        }

        public abstract void AlterarInformacoes(T entidade);
    }
}
