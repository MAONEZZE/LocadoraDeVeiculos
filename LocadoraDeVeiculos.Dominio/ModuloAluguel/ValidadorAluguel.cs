
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

            RuleFor(x => x.KMPercorrido)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(0)
                    .When(x => x.EstaAberto == false);

            RuleFor(x => x.DataLocacao)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThanOrEqualTo(DateTime.Now.AddHours(-1));

            RuleFor(x => x.DataDevolucaoPrevista)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(x => x.DataLocacao);

            RuleFor(x => x.DataDevolucao)
                    .NotNull()
                    .NotEmpty()
                    .GreaterThan(x => x.DataLocacao)
                    .When(x => x.EstaAberto == false);

            RuleFor(x => x.NivelCombustivelAtual)
                    .NotNull()
                    .NotEmpty()
                    .When(x => x.EstaAberto == false);

        }
    }
}
