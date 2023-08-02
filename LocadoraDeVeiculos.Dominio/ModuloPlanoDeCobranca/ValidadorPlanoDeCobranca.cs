namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>, IValidadorPlanoDeCobranca
    {
        public ValidadorPlanoDeCobranca()
        {
             RuleFor(x => x.KmDisponivel)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PrecoKm)
                .NotNull() 
                .NotEmpty();

            RuleFor(x => x.PrecoDiaria)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TipoPlano.ToString())
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.GrupoAutomovel)
                .NotNull()
                .NotEmpty();
        }
    }
}
