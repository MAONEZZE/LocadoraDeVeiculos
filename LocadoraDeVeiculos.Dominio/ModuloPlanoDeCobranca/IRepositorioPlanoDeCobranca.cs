using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorioBase<PlanoDeCobranca>
    {
        public bool EhValido(PlanoDeCobranca planoCobranca);

        public List<PlanoDeCobranca> SelecionarPlanoDeCobrancaPorGrupoAutomovel(GrupoAutomovel grupoAutomovel);
    }
}
