
namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(x => x.Funcionario)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Condutor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.GrupoAutomovel)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Automovel)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PlanoDeCobranca)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataLocacao)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);

            RuleFor(x => x.DataDevolucao)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now);           

            RuleFor(x => x.TaxasServicos)
                .NotNull()
                .NotEmpty();

     
        }
    }
}
