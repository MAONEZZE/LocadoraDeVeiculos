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
        public string NomePlano { get; set;}
        public decimal TotalPreco { get; set; }

        public PlanoDeCobranca() { }
        public PlanoDeCobranca(Guid id, int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel, string nomePlano) : this()
        {
            base.Id = id;
            this.KmDisponivel = kmDisponivel;
            this.PrecoKm = precoKm;
            this.PrecoDiaria = precoDiaria;
            this.TipoPlano = tipoPlano;
            this.GrupoAutomovel = grupoAutomovel;
            this.NomePlano = nomePlano;
        }

        public PlanoDeCobranca(int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel, string nomePlano) : this()
        {
            this.KmDisponivel = kmDisponivel;
            this.PrecoKm = precoKm;
            this.PrecoDiaria = precoDiaria;
            this.TipoPlano = tipoPlano;
            this.GrupoAutomovel = grupoAutomovel;
            this.NomePlano = nomePlano;
        }

        public override void AlterarInformacoes(PlanoDeCobranca entidade)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca planoC 
                && Id == planoC.Id 
                && NomePlano == planoC.NomePlano
                && KmDisponivel == planoC.KmDisponivel
                && PrecoKm == planoC.PrecoKm
                && PrecoDiaria == planoC.PrecoDiaria
                && TipoPlano == planoC.TipoPlano
                && GrupoAutomovel == planoC.GrupoAutomovel;
        }

        public void CalculoTotalPreco(int kmAutomovel)
        {

            switch (TipoPlano)
            {
                case TipoPlanoEnum.Diario:
                    TotalPreco = (kmAutomovel * PrecoKm) + PrecoDiaria;
                    break;

                case TipoPlanoEnum.Controlado:
                    //TotalPreco = 
                    break;
            }
        }
    }
}
