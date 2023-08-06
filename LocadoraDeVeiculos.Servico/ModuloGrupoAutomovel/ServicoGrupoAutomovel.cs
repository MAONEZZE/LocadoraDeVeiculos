
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel: ServicoBase<GrupoAutomovel, ValidadorGrupoAutomovel>
    {
        IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        IRepositorioAutomovel repositorioAutomovel;

        public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupo, IRepositorioAutomovel repositorioAutomovel)
        {
            this.repositorioGrupoAutomovel = repositorioGrupo;

            this.repositorioAutomovel = repositorioAutomovel;
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

                var erros = ValidarGrupo(grupo);

                if(erros.Any())
                {
                    Log.Warning("Esse grupo de veículo ja está sendo utilizado e nao pode ser excluido", grupo.Id);

                    return Result.Fail(erros);
                }

                if (!existe)
                {
                    Log.Warning("Grupo de automóveis {parceiroId} não encontrado para excluir", grupo.Id);

                    return Result.Fail("Parceiro não encontrada");
                }

                repositorioGrupoAutomovel.Excluir(grupo);

                Log.Debug("Grupo de automóveis {grupoId} excluído com sucesso", grupo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg = $"Falha ao tentar excluír grupo {grupo.Id}";

                repositorioGrupoAutomovel.DesfazerAlteracoes();

                Log.Error(msg +" "+ ex.Message, grupo);

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarGrupo(GrupoAutomovel grupo)
        {
            var erros = new List<string>();

            var utilizado = repositorioAutomovel.SelecionarPorGrupoAutomovel(grupo).Any();

            if (utilizado)
                erros.Add("Esse grupo de veículo ja está sendo utilizado");

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
