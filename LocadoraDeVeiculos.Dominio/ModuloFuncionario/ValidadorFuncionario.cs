using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;


namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250)
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Salario)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.DataAdmissao)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now);
        }
    }
}
