using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Servico.ModuloCupom
{
    public class ServicoCupom : ServicoBase<Cupom, ValidadorCupom>
    {
        private IRepositorioCupom repositorioCupom;
        private readonly IRepositorioAluguel repositorioAluguel;
        private IContextoPersistencia contexto;


        public ServicoCupom(IRepositorioCupom repositorioCupom, IRepositorioAluguel repositorioAluguel, IContextoPersistencia contexto)
        {
            this.repositorioCupom = repositorioCupom;
            this.repositorioAluguel = repositorioAluguel;
            this.contexto = contexto;
        }

        public Result Inserir(Cupom cupom)
        {
            Log.Debug("Tentando inserir cupom {@c}", cupom);

            var erros = ValidarCupom(cupom);

            if (erros.Any())
            {
                contexto.DesfazerAlteracoes();

                Log.Error(erros[0], cupom);

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Inserir(cupom);

                contexto.GravarDados();

                Log.Debug("Cupom {cupomId} inserido com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar inserir cupom {cupom}";

                contexto.DesfazerAlteracoes();

                Log.Error(msg, cupom);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Cupom cupom)
        {
            Log.Debug("Tentando editar cupom {@c}", cupom);

            var erros = ValidarCupom(cupom);

            if (erros.Any())
            {
                contexto.DesfazerAlteracoes();

                Log.Error(erros[0], cupom);

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Editar(cupom);

                contexto.GravarDados();

                Log.Debug("Cupom {cupomId} editado com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar cupom {cupom}";

                contexto.DesfazerAlteracoes();

                Log.Error(msg, cupom);

                return Result.Fail(msg);
            }
        }

        public Result Excluir(Cupom cupom)
        {
            Log.Debug("Tentando excluir cupom {@c}", cupom);

            try
            {
                var existe = repositorioCupom.Existe(cupom);

                if (!existe)
                {
                    Log.Warning("Cupom {cupomId} não encontrado para excluir", cupom.Id);

                    return Result.Fail("Cupom não encontrado");
                }

                repositorioCupom.Excluir(cupom);

                contexto.GravarDados();

                Log.Debug("Cupom {cupomId} excluído com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar excluir cupom {cupom}";

                contexto.DesfazerAlteracoes();

                Log.Error(msg, cupom);

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarCupom(Cupom cupom)
        {
            var erros = new List<string>();

            var resultado = Validar(cupom);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }

            if (repositorioAluguel.SelecionarTodos().Any(x => x.Cupom.Equals(cupom)))
                erros.Add("Este cupom já esta sendo utilizado, não é possivel editar ou excluir");

            if (!repositorioCupom.EhValido(cupom))
                erros.Add($"Este nome '{cupom.Nome}' já está sendo utilizado");

            return erros;
        }
    }
}
