using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>
    {
        private readonly IRepositorioCondutor repCondutor;

        private readonly IRepositorioAluguel repositorioAluguel;

        private IContextoPersistencia contexto;

        public ServicoCondutor(IRepositorioCondutor repCondutor, IRepositorioAluguel repositorioAluguel, IContextoPersistencia contexto)
        {
            this.repCondutor = repCondutor;
            this.repositorioAluguel = repositorioAluguel;
            this.contexto = contexto;
        }

        public List<Condutor> CondutoreRelacionadosCliente(Cliente cliente)
        {
            return repCondutor.SelecionarTodos().Where(x => x.Cliente.Equals(cliente)).ToList();
        }

        public Result Inserir(Condutor condutor)
        {
            Log.Debug("Tentando inserir condutor {@c}", condutor);

            var erros = ValidarCondutor(condutor);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                repCondutor.Inserir(condutor);

                Log.Debug("Condutor {condutorId} inserido com sucesso", condutor.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar inserir condutor {condutor}";

                Log.Error(msg, condutor);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }

        }

        public Result Editar(Condutor condutor)
        {
            Log.Debug("Tentando editar condutor {@c}", condutor);

            var erros = ValidarCondutor(condutor);

            if (erros.Any())
                return Result.Fail(erros);

            try
            {
                int quantidadeEmAlugueisAtivos = repositorioAluguel.ObterQuantidadeDeAlugueisAtivosCom(condutor);

                if (quantidadeEmAlugueisAtivos > 0)
                {
                    Log.Warning("Condutor {condutorId} não pode ser editado, pois está em uso em um aluguel ativo", condutor.Id);

                    return Result.Fail($"Condutor {condutor.Nome} não pode ser editado, pois está em uso em um aluguel ativo");
                }

                repCondutor.Editar(condutor);

                Log.Debug("Condutor {condutorId} editado com sucesso", condutor.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (SqlException)
            {
                string msg = $"Falha ao tentar editar condutor {condutor}";

                Log.Error(msg, condutor);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }

        }

        public Result Excluir(Condutor condutor)
        {
            Log.Debug("Tentando excluir condutor {@c}", condutor);

            try
            {
                var existe = repCondutor.Existe(condutor);

                if (!existe)
                {
                    Log.Warning("Condutor {condutorId} não encontrado para excluir", condutor.Id);

                    return Result.Fail("Condutor não encontrado");
                }

                int quantidadeEmAlugueisAtivos = repositorioAluguel.ObterQuantidadeDeAlugueisAtivosCom(condutor);
                int quantidadeEmAlugueisConcluido = repositorioAluguel.ObterQuantidadeDeAlugueisConcluidosCom(condutor);

                int totalEmUso = quantidadeEmAlugueisAtivos + quantidadeEmAlugueisConcluido;

                if (totalEmUso > 0)
                {
                    Log.Warning("Não é possível excluir Condutor {condutorId}, pois está associado a aluguel(is)", condutor.Id, totalEmUso);

                    return Result.Fail($"Não é possível excluir Condutor {condutor.Nome}, pois está associado a aluguel(is)");
                }

                repCondutor.Excluir(condutor);

                Log.Debug("Condutor {condutorId} excluído com sucesso", condutor.Id);

                contexto.GravarDados();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msg;

                msg = $"Falha ao tentar excluir condutor {condutor}";

                Log.Error(msg, condutor);

                contexto.DesfazerAlteracoes();

                return Result.Fail(msg);
            }
        }

        private List<string> ValidarCondutor(Condutor condutor)
        {
            var erros = new List<string>();

            var resultado = Validar(condutor);

            if (resultado.IsFailed)
            {
                erros.AddRange(resultado.Errors.Select(e => e.Message));
            }

            if (!repCondutor.EhValido(condutor))
                erros.Add($"Este nome '{condutor.Nome}' já está sendo utilizado");

            return erros;
        }
    }
}
