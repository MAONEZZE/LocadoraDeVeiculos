namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public interface IRepositorioTaxaServico : IRepositorioBase<TaxaServico>
    {
        TaxaServico BuscarPorNome(string nome);

        bool EhValido(TaxaServico taxaServico);
    }
}
