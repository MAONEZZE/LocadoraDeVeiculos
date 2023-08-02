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
