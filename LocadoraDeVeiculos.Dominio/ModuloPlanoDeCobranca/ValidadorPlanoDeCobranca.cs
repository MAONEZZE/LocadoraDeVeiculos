using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>, IValidadorPlanoDeCobranca
    {
        public ValidadorPlanoDeCobranca()
        {

            When(x => x.TipoPlano == TipoPlanoEnum.Livre, () => 
            {
                RuleFor(x => x.PrecoDiaria)
                .NotNull()
                .NotEmpty();
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Diario, () =>
            {
                RuleFor(x => x.PrecoDiaria)
                .NotNull()
                .NotEmpty();

                RuleFor(x => x.PrecoKm)
                .NotNull()
                .NotEmpty();
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Controlado, () =>
            {
                RuleFor(x => x.PrecoDiaria)
                .NotNull()
                .NotEmpty();

                RuleFor(x => x.PrecoKm)
                .NotNull()
                .NotEmpty();

                RuleFor(x => x.KmDisponivel)
                .NotNull()
                .NotEmpty();
            });

            RuleFor(x => x.GrupoAutomovel)
                .NotNull()
                .NotEmpty();
        }
    }
}
