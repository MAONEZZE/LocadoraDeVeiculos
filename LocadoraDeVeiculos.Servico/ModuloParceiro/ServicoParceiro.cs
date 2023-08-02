using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.Servico.ModuloParceiro
{
    public class ServicoParceiro : ServicoBase<Parceiro, ValidadorParceiro>
    {
        IRepositorioParceiro repositorioParceiro;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
        }

        public Result Inserir(Parceiro parceiro)
        {
            Log.Debug("Tentando inserir parceiro {@p}", parceiro);

            var erros = ValidarParceiro(parceiro);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioParceiro.Inserir(parceiro);

                Log.Debug("Parceiro {parceiroId} inserido com sucesso", parceiro.Id);

                return Result.Ok();
            }

            catch
            {
                string msg = $"Falha ao tentar inserir parceiro {parceiro}";

                repositorioParceiro.DesfazerAlteracoes();

                Log.Error(msg, parceiro);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Parceiro parceiro)
        {
            Log.Debug("Tentando editar parceiro {@p}", parceiro);

            var erros = ValidarParceiro(parceiro);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repositorioParceiro.Editar(parceiro);

                Log.Debug("Parceiro {parceiroId} editado com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch
            {
                string msg = $"Falha ao tentar editar parceiro {parceiro}";

                repositorioParceiro.DesfazerAlteracoes();

                Log.Error(msg, parceiro);

                return Result.Fail(msg);
            }
        }

        public Result Excluir(Parceiro parceiro)
        {
            Log.Debug("Tentando excluir parceiro {@p}", parceiro);

            try
            {
                var existe = repositorioParceiro.Existe(parceiro);

                if (!existe)
                {
                    Log.Warning("Parceiro {parceiroId} não encontrado para excluir", parceiro.Id);

                    return Result.Fail("Parceiro não encontrado");
                }

                repositorioParceiro.Excluir(parceiro);

                Log.Debug("Parceiro {parceiroId} excluído com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;

                if (ex.Message.Contains("'Parceiro' and 'Cupom'") ||

                    ex.InnerException.Message.Contains("FK_TBCupom_TBParceiro_ParceiroId"))
                {
                    msg = "Este parceiro está relacionado com um cupom e não pode ser excluído.";
                }
                else
                    msg = $"Falha ao tentar excluír parceiro {parceiro}";

                repositorioParceiro.DesfazerAlteracoes();

                Log.Error(msg, parceiro);

                return Result.Fail(msg);
            }

        }

        private List<string> ValidarParceiro(Parceiro parceiro)
        {
            var erros = new List<string>();

            var resultado = Validar(parceiro);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }
            var ehValido = repositorioParceiro.EhValido(parceiro);

            if (!ehValido)
                erros.Add($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            return erros;
        }

    }
}
