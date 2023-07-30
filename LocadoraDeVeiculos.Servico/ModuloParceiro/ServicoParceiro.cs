using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Serilog;
using System.Data.SqlClient;

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
            catch (SqlException)
            {
                string msg = $"Falha ao tentar inserir parceiro {parceiro}";

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
            catch (SqlException)
            {
                string msg = $"Falha ao tentar editar parceiro {parceiro}";

                Log.Error(msg, parceiro);

                return Result.Fail(msg);
            }


        }

        public Result Excluir(Parceiro parceiro)
        {
            Log.Debug("Tentando excluir parceiro {@p}", parceiro);

            try
            {
                repositorioParceiro.Excluir(parceiro);

                Log.Debug("Parceiro {parceiroId} excluído com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                string msg;

                if (ex.Message.Contains("FK_TBPARCEIRO_TBCUPOM"))
                {
                    msg = "Este parceiro está relacionado com um cupom e nãp pode ser excluído";
                }
                else
                    msg = $"Falha ao tentar exlcui parceiro {parceiro}";

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

            if (!repositorioParceiro.EhValido(parceiro))
                erros.Add($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            return erros;
        }

    }
}
