using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        bool EhValido(Aluguel aluguel);

        public int ObterQuantidadeDeAlugueisAtivosCom(Object registro);

        public int ObterQuantidadeDeAlugueisConcluidosCom(Object registro);
    }
}
