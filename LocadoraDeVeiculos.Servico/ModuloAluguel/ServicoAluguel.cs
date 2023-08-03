using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Servico.ModuloAluguel
{
    public class ServicoAluguel : ServicoBase<Aluguel, ValidadorAluguel>
    {
        private IRepositorioAluguel repositorioAluguel;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir Aluguel... {@aluguel}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Inserir(aluguel);

                Log.Debug("Aluguel {AluguelId} inserido com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar inserir Aluguel.";

                Log.Error(ex, msgErro + " {aluguel}", aluguel);

                return Result.Fail(msgErro);
            }
        }


        public Result Editar(Aluguel aluguel)
        {
            Log.Debug($"Tentando editar Aluguel... {aluguel}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Editar(aluguel);

                Log.Debug("Aluguel {AluguelId} editado com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar editar Aluguel.";

                Log.Error(ex, msgErro + " {aluguel}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug($"Tentando excluir Aluguel... {aluguel}", aluguel);

            try
            {
                bool aluguelExiste = repositorioAluguel.Existe(aluguel);

                if (aluguelExiste == false) {

                    Log.Warning("Aluguel {AluguelId} não encontrado!", aluguel.Id);

                    return Result.Fail("Aluguel não existe!");
                }

                repositorioAluguel.Excluir(aluguel);

                Log.Debug("Aluguel {AluguelId} excluído com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<String> erros = new();

                string msgErro = "Erro desconhecido. Falha ao tentar excluir Aluguel.";

                Log.Error(ex, msgErro + " {aluguelId}", aluguel.Id);

                erros.Add(msgErro);

                return Result.Fail(erros);
            }
        }

        private List<String> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = Validar(aluguel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
            {
                erros.AddRange(resultadoValidacao.Errors.Select(e => e.Message));
            }

            return erros;
        }
    }
}
