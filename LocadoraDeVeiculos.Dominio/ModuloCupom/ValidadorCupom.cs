namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
    {
       public ValidadorCupom()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataValidade)
                .NotEmpty()
                .GreaterThanOrEqualTo(x=> DateTime.Now.Date);

            RuleFor(x => x.Valor)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x=>x.Parceiro)
                .NotNull();
        }
    }
}
