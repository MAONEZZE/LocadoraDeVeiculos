using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>
    {
        public ValidadorParceiro()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
