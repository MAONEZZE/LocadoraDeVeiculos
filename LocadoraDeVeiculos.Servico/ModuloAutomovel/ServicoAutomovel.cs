using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Servico.ModuloAutomovel
{
    public class ServicoAutomovel : ServicoBase<Automovel,ValidadorAutomovel>
    {
        IRepositorioAutomovel repositorioAutomovel;

        public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
        }

        public Result Inserir(Automovel automovel)
        {
            Log.Debug("Tentando inserir automovel {@c}", automovel);

            var erros = ValidarAutomovel(automovel);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Inserir(automovel);

                Log.Debug("Automovel {automovelId} inserido com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar inserir automovel {automovel}";

                repositorioAutomovel.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Automovel automovel)
        {
            Log.Debug("Tentando editar automovel {@p}", automovel);

            var erros = ValidarAutomovel(automovel);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Editar(automovel);

                Log.Debug("Automovel {automovelId} editado com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar automovel {automovel}";

                repositorioAutomovel.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }
        }

        public Result Excluir(Automovel automovel)
        {
            Log.Debug("Tentando excluir automovel {@p}", automovel);

            try
            {
                var existe = repositorioAutomovel.Existe(automovel);

                if (!existe)
                {
                    Log.Warning("Automóvel {automovelId} não encontrado para excluir", automovel.Id);

                    return Result.Fail("Automóvel não encontrado");
                }

                if (!repositorioAutomovel.EstaDisponivel(automovel))
                {
                    string msg = $"Este automóvel placa: '{automovel.Placa}' já está sendo utilizado em um aluguel.";

                    Log.Warning(msg + " {automovelId}", automovel.Id);

                    return Result.Fail(msg);
                }

                repositorioAutomovel.Excluir(automovel);

                Log.Debug("Automóvel {automovelId} excluído com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = $"Falha ao tentar excluír automovel {automovel} - {ex.Message}";

                repositorioAutomovel.DesfazerAlteracoes();

                Log.Error(msg, automovel);

                return Result.Fail(msg);
            }



        }

        private List<string> ValidarAutomovel(Automovel automovel)
        {
            var erros = new List<string>();

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
