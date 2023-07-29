using FluentResults;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IGeradorEmail
    {
        Result EnviarEmail(Aluguel aluguel);
    }
}
