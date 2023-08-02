using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Documento)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Validade)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cnh)
                .NotNull()
                .NotEmpty()
                .Length(11);

            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty();
        }
    }
}
