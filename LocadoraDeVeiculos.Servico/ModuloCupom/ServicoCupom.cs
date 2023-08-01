using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Servico.ModuloCupom
{
    public class ServicoCupom : ServicoBase<Cupom, ValidadorCupom>
    {
        IRepositorioCupom repositorioCupom;
       

        public ServicoCupom(IRepositorioCupom repositorioCupom)
        {           
            this.repositorioCupom = repositorioCupom;
        }

        public Result Inserir(Cupom cupom)
        {
            Log.Debug("Tentando inserir cupom {@c}", cupom);

            var erros = ValidarCupom(cupom);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioCupom.Inserir(cupom);
            
                Log.Debug("Cupom {cupomId} inserido com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar inserir cupom {cupom}";

                repositorioCupom.DesfazerAlteracoes();

                Log.Error(msg, cupom);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Cupom cupom)
        {
            Log.Debug("Tentando editar cupom {@c}", cupom);

            var erros = ValidarCupom(cupom);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioCupom.Editar(cupom);
              
                Log.Debug("Cupom {cupomId} editado com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar cupom {cupom}";

                repositorioCupom.DesfazerAlteracoes();

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
             
                Log.Debug("Cupom {cupomId} excluído com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;                  // aguaradar nome fk aluguel _ cupom
                                            // nao pode excluir cupom relacionado a aluguel..
                if (ex.InnerException!.Message.Contains(""))
                {
                    msg = "Este cupom está relacionado com um aluguel e pode ser excluído";
                }
                else
                    msg = $"Falha ao tentar excluir cupom {cupom}";

                repositorioCupom.DesfazerAlteracoes();

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
          
            if (!repositorioCupom.EhValido(cupom))
                erros.Add($"Este nome '{cupom.Nome}' já está sendo utilizado");

            return erros;
        }
    }
}
