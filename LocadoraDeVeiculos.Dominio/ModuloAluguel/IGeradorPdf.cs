namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IGeradorPdf
    {
        byte[] GerarPdfEmail(Aluguel aluguel);
    }
}
