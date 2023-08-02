using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public Result Inserir(Funcionario funcionario)
        {
            Log.Debug("Tentando inserir Funcionário... {@funcionario}", funcionario);

            List<string> erros = ValidarFuncionario(funcionario);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);

                Log.Debug("Funcionário {FuncionarioId} inserido com sucesso!", funcionario.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar inserir Funcionário.";

                Log.Error(ex, msgErro + " {funcionario}", funcionario);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Funcionario funcionario)
        {
            Log.Debug($"Tentando editar Funcionário... {funcionario}", funcionario);

            List<string> erros = ValidarFuncionario(funcionario);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);

                Log.Debug("Funcionário {FuncionarioId} editado com sucesso!", funcionario.Id);

                return Result.Ok();
            }
            catch(Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar editar Funcionário.";

                Log.Error(ex, msgErro + " {funcionario}", funcionario);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Debug($"Tentando excluir Funcionário... {funcionario}", funcionario);

            try
            {
                bool funcionarioExiste = repositorioFuncionario.Existe(funcionario);

                if (funcionarioExiste == false) { 
                    Log.Warning("Funcionário {FuncionarioId} não encontrado!", funcionario.Id);

                    return Result.Fail("Funcionário não existe");
                }

                repositorioFuncionario.Excluir(funcionario);

                Log.Debug("Funcionário {FuncionarioId} excluído com sucesso!", funcionario.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new();

                string msgErro;

                if (ex.Number == 547)
                {
                    msgErro = "Não é possível excluir o Funcionário, pois ele está sendo referenciado por outros registros.";
                }
                else
                {
                    msgErro = "Erro desconhecido. Falha ao tentar excluir Funcionário.";
                }

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {funcionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        private List<string> ValidarFuncionario(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            List<string> erros = new();

            if (resultadoValidacao != null)
            {
                erros.AddRange(resultadoValidacao.Errors.Select(e => e.Message));
            }

            if (NomeDuplicado(funcionario))
            {
                  erros.Add($"Já existe um Funcionário com o nome '{funcionario.Nome}'");
            }

            foreach(string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            Funcionario funcionarioEncontrado = repositorioFuncionario.BuscarPorNome(funcionario.Nome);

            if(funcionarioEncontrado == null)
            {
                return false;
            }


            if(funcionarioEncontrado.Id == funcionario.Id)
            {
                return false;
            }

            if (funcionarioEncontrado.Nome == funcionario.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
