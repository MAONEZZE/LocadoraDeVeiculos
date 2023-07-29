namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T> where T: EntidadeBase<T>
    {
        public int Id { get; set; }

        public abstract void AlterarInformacoes(T entidade);
    }
}
