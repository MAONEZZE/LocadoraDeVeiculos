using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>
    {
        private IRepositorioCliente repCliente;

        public ServicoCliente(IRepositorioCliente repCliente)
        {
            this.repCliente = repCliente;
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir cliente {@c}", cliente);

            var erros = ValidarCliente(cliente);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repCliente.Inserir(cliente);

                Log.Debug("Cliente {clienteId} inserido com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar inserir cliente {cliente}";

                Log.Error(msg, cliente);

                return Result.Fail(msg);
            }

        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente {@c}", cliente);

            var erros = ValidarCliente(cliente);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repCliente.Editar(cliente);

                Log.Debug("Cliente {clienteId} editado com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar editar cliente {cliente}";

                Log.Error(msg, cliente);

                return Result.Fail(msg);
            }


        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente {@c}", cliente);

            try
            {
                var existe = repCliente.Existe(cliente);

                if (!existe)
                {
                    Log.Warning("Cliente {clienteId} não encontrado para excluir", cliente.Id);

                    return Result.Fail("Cliente não encontrado");
                }

                repCliente.Excluir(cliente);

                Log.Debug("Cliente {clienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;

                if (ex.Message.Contains("FK_TBCondutor_TBCliente_ClienteId"))
                {
                    msg = "Este cliente está relacionado com um Condutor e não pode ser excluído";
                }
                else
                    msg = $"Falha ao tentar excluir cliente {cliente}";

                Log.Error(msg, cliente);

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarCliente(Cliente cliente)
        {
            var erros = new List<string>();

            var resultado = Validar(cliente);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }

            if (!repCliente.EhValido(cliente))
                erros.Add($"Este nome '{cliente.Nome}' já está sendo utilizado");

            return erros;
        }
    }
}
