
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel: ServicoBase<GrupoAutomovel, ValidadorGrupoAutomovel>
    {
        IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupo)
        {
            this.repositorioGrupoAutomovel = repositorioGrupo;
        }

        public Result Inserir(GrupoAutomovel grupo)
        {
            Log.Debug("Tentando inserir grupo {@p}", grupo);

            var erros = ValidarGrupo(grupo);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Inserir(grupo);

                Log.Debug("Grupo de Automóveis {grupoId} inserido com sucesso", grupo.Id);

                return Result.Ok();
            }

            catch
            {
                string msg = $"Falha ao tentar inserir Grupo de Automóveis {grupo.Id}";

                repositorioGrupoAutomovel.DesfazerAlteracoes();

                Log.Error(msg, grupo);

                return Result.Fail(msg);
            }

        }

        public Result Editar(GrupoAutomovel grupo)
        {
            Log.Debug("Tentando editar Grupo de Automóveis {@p}", grupo);

            var erros = ValidarGrupo(grupo);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Editar(grupo);

                Log.Debug("Grupo {grupoId} editado com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar grupo {grupo}";

                repositorioGrupoAutomovel.DesfazerAlteracoes();

                Log.Error(msg, grupo);

                return Result.Fail(msg);
            }


        }

        public Result Excluir(GrupoAutomovel grupo)
        {
            Log.Debug("Tentando excluir grupo {@p}", grupo);

            try
            {
                var existe = repositorioGrupoAutomovel.Existe(grupo);

                if (!existe)
                {
                    Log.Warning("Parceiro {parceiroId} não encontrado para excluir", grupo.Id);

                    return Result.Fail("Parceiro não encontrada");
                }

                repositorioGrupoAutomovel.Excluir(grupo);

                Log.Debug("Parceiro {parceiroId} excluído com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;

                if (ex.Message.Contains("") ||
                    ex.InnerException.Message.Contains(""))
                {
                    msg = "Este grupo está relacionado com um automóvel e não pode ser excluído.";
                }
                else
                    msg = $"Falha ao tentar excluír grupo {grupo.Id}";

                repositorioGrupoAutomovel.DesfazerAlteracoes();

                Log.Error(msg, grupo);

                return Result.Fail(msg);
            }



        }

        private List<string> ValidarGrupo(GrupoAutomovel grupo)
        {
            var erros = new List<string>();

            var resultado = Validar(grupo);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }
            var ehValido = repositorioGrupoAutomovel.EhValido(grupo);

            if (ehValido == false)
                erros.Add($"Este nome '{grupo.Nome}' já está sendo utilizado");

            return erros;
        }

    }
}
