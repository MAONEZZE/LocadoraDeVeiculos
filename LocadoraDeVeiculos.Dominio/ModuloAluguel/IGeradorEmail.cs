using FluentResults;
using System.Reflection.Metadata;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IGeradorEmail
    {
        Result EnviarEmail(Aluguel aluguel);
    }
}
