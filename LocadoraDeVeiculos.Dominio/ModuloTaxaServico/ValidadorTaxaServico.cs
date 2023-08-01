﻿namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class ValidadorTaxaServico : AbstractValidator<TaxaServico>, IValidadorTaxaServico
    {
        public ValidadorTaxaServico()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MaximumLength(250)
                .MinimumLength(2)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
