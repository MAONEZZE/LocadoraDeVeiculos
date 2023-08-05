using System.Reflection.Metadata;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IGeradorPdf
    {
        void GerarPdf(Aluguel aluguel);

        string ObterCaminhoArquivo();
    }
}
