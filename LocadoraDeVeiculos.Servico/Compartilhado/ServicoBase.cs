using FluentResults;
using FluentValidation;
using Serilog;

namespace LocadoraDeVeiculos.Servico.Compartilhado
{
    public abstract class ServicoBase<T, TValidador> 
        where TValidador : AbstractValidator<T>, new()
    {
        protected virtual Result Validar(T obj)
        {
            var validador = new TValidador();

            var resultadoValidacao = validador.Validate(obj);

            var erros = new List<Error>();

            foreach (var validationFailure in resultadoValidacao.Errors)
            {
                Log.Warning(validationFailure.ErrorMessage);

                erros.Add(new Error(validationFailure.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
