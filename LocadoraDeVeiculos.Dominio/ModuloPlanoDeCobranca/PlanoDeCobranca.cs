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

        public PlanoDeCobranca() { }
        public PlanoDeCobranca(Guid id, int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel) : this()
        {
            base.Id = id;
            this.KmDisponivel = kmDisponivel;
            this.PrecoKm = precoKm;
            this.PrecoDiaria = precoDiaria;
            this.TipoPlano = tipoPlano;
            this.GrupoAutomovel = grupoAutomovel;
        }

        public PlanoDeCobranca(int kmDisponivel, decimal precoKm, decimal precoDiaria, TipoPlanoEnum tipoPlano, GrupoAutomovel grupoAutomovel) : this()
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

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca planoC 
                && Id == planoC.Id 
                && KmDisponivel == planoC.KmDisponivel
                && PrecoKm == planoC.PrecoKm
                && PrecoDiaria == planoC.PrecoDiaria
                && TipoPlano == planoC.TipoPlano
                && GrupoAutomovel == planoC.GrupoAutomovel;
        }

        public decimal CalculoTotalPreco(int kmAutomovel, int diasUsados)
        {
            decimal totalPreco = 0;

            switch (TipoPlano)
            {
                case TipoPlanoEnum.Diario:
                    totalPreco = (kmAutomovel * PrecoKm) + (PrecoDiaria * diasUsados);
                    break;

                case TipoPlanoEnum.Controlado:
                    var kmExcedente = kmAutomovel - KmDisponivel;

                    if (kmExcedente > 0)
                    {
                        totalPreco = (kmExcedente * PrecoKm) + (PrecoDiaria * diasUsados);
                    }
                    else
                    {
                        totalPreco = (PrecoDiaria * diasUsados);
                    }
                    break;

                case TipoPlanoEnum.Livre:
                    totalPreco = (PrecoDiaria * diasUsados);
                    break;
            }

            return totalPreco;
        }
    }
}
