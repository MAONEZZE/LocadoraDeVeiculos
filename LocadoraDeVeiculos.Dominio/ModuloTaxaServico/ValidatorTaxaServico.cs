namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class ValidatorTaxaServico : AbstractValidator<TaxaServico>, IValidatorTaxaServico
    {
        public ValidatorTaxaServico()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")
                .MaximumLength(250)
                .WithMessage("O nome não pode ter mais de 250 caracteres")
                .MinimumLength(2)
                .WithMessage("O nome não pode ter menos de 2 caracteres")
                .NaoPodeCaracteresEspeciais();
        }
    }
}
