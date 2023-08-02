using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
