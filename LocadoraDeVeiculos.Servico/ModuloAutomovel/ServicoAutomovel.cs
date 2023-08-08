using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Servico.ModuloAutomovel
{
    public class ServicoAutomovel : ServicoBase<Automovel,ValidadorAutomovel>
    {
        IRepositorioAutomovel repositorioAutomovel;

        IRepositorioAluguel repositorioAluguel;

        public IContextoPersistencia Contexto;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel, IRepositorioAluguel repositorioAluguel, IContextoPersistencia contexto)
        {
            this.repositorioAutomovel = repositorioAutomovel;

            this.repositorioAluguel = repositorioAluguel;

            Contexto = contexto;
        }

        public Result Inserir(Automovel automovel)
        {
            Log.Debug("Tentando inserir automovel {@c}", automovel);

            var erros = ValidarAutomovel(automovel);

            if (erros.Any())
            {
                Contexto.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
               
            try
            {
                repositorioAutomovel.Inserir(automovel);
               
                Log.Debug("Automovel {automovelId} inserido com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar inserir automovel {automovel}";

                Contexto.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Automovel automovel)
        {
            Log.Debug("Tentando editar automovel {@p}", automovel);

            var erros = ValidarAutomovel(automovel);

            if (erros.Any())
            {
                Log.Warning("Não é possivel editar este automóvel {automovelId} pois esta sendo utilizado em um aluguel, ", automovel.Id);

                return Result.Fail(erros);
            }
               
            try
            {
                repositorioAutomovel.Editar(automovel);

                Log.Debug("Automóvel {automovelId} editado com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar automóvel {automovel}";

                Contexto.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }
        }

        public Result Excluir(Automovel automovel)
        {
            Log.Debug("Tentando excluir automóvel {@p}", automovel);

            try
            {
                var existe = repositorioAutomovel.Existe(automovel);

                if (!existe)
                {
                    Log.Warning("Automóvel {automovelId} não encontrado para excluir", automovel.Id);

                    return Result.Fail("Automóvel não encontrado");
                }

                var erros = ValidarAutomovel(automovel);

                if (erros.Any())
                {
                    Log.Warning("Não é possivel excluir este automóvel {automovelId} pois esta sendo utilizado em um aluguel, ", automovel.Id);

                    return Result.Fail(erros);
                }
                  
                repositorioAutomovel.Excluir(automovel);

                Log.Debug("Automóvel {automovelId} excluído com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = $"Falha ao tentar excluír automovel {automovel} - {ex.Message}";

                Contexto.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarAutomovel(Automovel automovel)
        {
            var erros = new List<string>();

            var alugado = repositorioAluguel.SelecionarTodos().Any(a => a.Automovel.Equals(automovel));

            if (alugado)
                erros.Add("Automóvel indisponível. Este automóvel está sendo utilizado em outro aluguel.");

            var resultado = Validar(automovel);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }

            if (!repositorioAutomovel.EhValido(automovel))
                erros.Add($"Esta placa '{automovel.Placa}' já está sendo utilizado");

            return erros;
        }
    }
}
