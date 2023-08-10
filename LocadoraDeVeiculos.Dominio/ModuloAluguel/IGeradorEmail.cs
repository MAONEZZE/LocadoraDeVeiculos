using FluentResults;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IGeradorEmail
    {    
        Result EnviarEmail(Aluguel aluguel, byte[] bytesAnexo = null!);

    }
}
