namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorioBase<PlanoDeCobranca>
    {
        public bool EhValido(PlanoDeCobranca planoCobranca);
    }
}
