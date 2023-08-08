using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca : ServicoBase<PlanoDeCobranca, ValidadorPlanoDeCobranca>
    {
        private IRepositorioPlanoDeCobranca repPlano;

        private IContextoPersistencia contexto;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repPlano, IContextoPersistencia contexto)
        {
            this.repPlano = repPlano;
            this.contexto = contexto;
        }

        public Result Inserir(PlanoDeCobranca plano)
        {
            Log.Debug("Tentando inserir plano de cobrança {@c}", plano);

            var erros = ValidarPlano(plano);

            if (erros.Any())
            {            
                return Result.Fail(erros);
            }
                
            try
            {
                repPlano.Inserir(plano);

                Log.Debug("Plano de Cobrança {planoId} inserido com sucesso", plano.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar inserir plano de cobrança {plano}";

                Log.Error(msg, plano);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }

        }

        public Result Editar(PlanoDeCobranca plano)
        {
            Log.Debug("Tentando editar plano de cobrança {@c}", plano);

            var erros = ValidarPlano(plano);

            if (erros.Any())
            {
                return Result.Fail(erros);
            }
                
            try
            {
                repPlano.Editar(plano);

                Log.Debug("Plano de cobrança {planoId} editado com sucesso", plano.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar editar plano de cobrança {plano}";

                Log.Error(msg, plano);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }


        }

        public Result Excluir(PlanoDeCobranca plano)
        {
            Log.Debug("Tentando excluir plano de cobrança {@c}", plano);

            try
            {
                var existe = repPlano.Existe(plano);

                if (!existe)
                {
                    Log.Warning("Plano de cobrança {planoId} não encontrado para excluir", plano.Id);

                    return Result.Fail("plano de cobrança não encontrado");
                }

                repPlano.Excluir(plano);

                Log.Debug("Plano de cobrança {planoId} excluído com sucesso", plano.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;

                if (ex.Message.Contains("FK_TBPlanoDeCobranca_TBGrupoAutomovel_GrupoAutomovelId"))
                {
                    msg = "Este Plano está relacionado com um Grupo de automovel e não pode ser excluído";
                }
                else
                    msg = $"Falha ao tentar excluir o Plano de cobrança{plano}";

                Log.Error(msg, plano);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarPlano(PlanoDeCobranca plano)
        {
            var erros = new List<string>();

            var resultado = Validar(plano);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }

            if (!repPlano.EhValido(plano))
                erros.Add($"Este plano já está sendo utilizado");

            return erros;
        }
    }
}
