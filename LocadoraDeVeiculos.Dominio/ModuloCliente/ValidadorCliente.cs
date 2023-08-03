using FluentValidation.Results;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente() 
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

            RuleFor(x => x.Endereco)
                .NotNull() 
                .NotEmpty()
                .Custom(VerificadorEndereco);

            RuleFor(x => x.TipoCliente.ToString())
                .NotEmpty()
                .NotNull();

        }

        private void VerificadorEndereco(Endereco endereco, ValidationContext<Cliente> ctx)
        {
            if(endereco.Bairro == null)
            {
                ctx.AddFailure(new ValidationFailure("Bairro", "O Bairro não pode ser nulo"));
            }

            if (endereco.Cidade == null)
            {
                ctx.AddFailure(new ValidationFailure("Cidade", "O Cidade não pode ser nulo"));
            }

            if (endereco.Estado == null)
            {
                ctx.AddFailure(new ValidationFailure("Estado", "O Estado não pode ser nulo"));
            }

            if (endereco.Numero <= 0)
            {
                ctx.AddFailure(new ValidationFailure("Número", "O Número da residencia não pode ser 0 ou menor que 0"));
            }

            if (endereco.Cep == null)
            {
                ctx.AddFailure(new ValidationFailure("CEP", "Digite um CEP válido"));
            }

            if (endereco.Logradouro == null)
            {
                ctx.AddFailure(new ValidationFailure("Logradouro", "O Logradouro não pode ser nulo"));
            }
        }
    }
}
