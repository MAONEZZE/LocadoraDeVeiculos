namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public class ValidadorGrupoAutomovel : AbstractValidator<GrupoAutomovel>, IValidadorGrupoAutomovel
    {
       public ValidadorGrupoAutomovel()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

         
        }
    }
}
