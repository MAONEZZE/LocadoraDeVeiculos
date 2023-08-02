using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public int KmDisponivel { get; set; }
        public decimal PrecoKm { get; set; }
        public decimal PrecoDiaria { get; set; }
        public TipoPlanoEnum TipoPlano { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }

        public PlanoDeCobranca(Guid id, int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel)
        {
            base.Id = id;
            this.KmDisponivel = kmDisponivel;
            this.PrecoKm = precoKm;
            this.PrecoDiaria = precoDiaria;
            this.TipoPlano = tipoPlano;
            this.GrupoAutomovel = grupoAutomovel;
        }

        public PlanoDeCobranca(int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel)
        {
            this.KmDisponivel = kmDisponivel;
            this.PrecoKm = precoKm;
            this.PrecoDiaria = precoDiaria;
            this.TipoPlano = tipoPlano;
            this.GrupoAutomovel = grupoAutomovel;
        }

        public override void AlterarInformacoes(PlanoDeCobranca entidade)
        {
            throw new NotImplementedException();
        }
    }
}
