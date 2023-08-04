namespace LocadoraDeVeiculos.WinApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade entidade)
        where TEntidade : EntidadeBase<TEntidade>;
}
