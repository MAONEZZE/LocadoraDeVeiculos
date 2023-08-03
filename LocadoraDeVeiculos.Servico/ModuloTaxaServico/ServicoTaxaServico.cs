using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Servico.ModuloTaxaServico
{
    public class ServicoTaxaServico : ServicoBase<TaxaServico, ValidadorTaxaServico>
    {
        private IRepositorioTaxaServico repositorioTaxaServico;

        public ServicoTaxaServico(IRepositorioTaxaServico repositorioTaxaServico)
        {
            this.repositorioTaxaServico = repositorioTaxaServico;
        }


        public Result Inserir(TaxaServico taxaServico)
        {
            Log.Debug("Tentando inserir Taxa ou Serviço... {@ts}", taxaServico);

            List<string> erros = ValidarTaxaServico(taxaServico);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxaServico.Inserir(taxaServico);

                Log.Debug("Taxa ou Serviço {TaxaServicoId} inserido com sucesso!", taxaServico.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar inserir Taxa ou Serviço.";

                Log.Error(ex, msgErro + " {TaxaServico}", taxaServico);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(TaxaServico taxaServico)
        {
            Log.Debug($"Tentando editar Taxa ou Serviço... {taxaServico}", taxaServico);

            List<string> erros = ValidarTaxaServico(taxaServico);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxaServico.Editar(taxaServico);

                Log.Debug("Taxa ou Serviço {TaxaServicoId} editado com sucesso!", taxaServico.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar editar Taxa ou Serviço.";

                Log.Error(ex, msgErro + " {TaxaServico}", taxaServico);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(TaxaServico taxaServico)
        {
            Log.Debug($"Tentando excluir Taxa ou Serviço... {taxaServico}", taxaServico);

            try
            {
                bool taxaServicoExiste = repositorioTaxaServico.Existe(taxaServico);

                if (taxaServicoExiste == false)
                {
                    Log.Warning("Taxa ou Serviço {TaxaServicoId} não existe", taxaServico.Id);

                    return Result.Fail("Taxa ou Serviço não existe");
                }

                repositorioTaxaServico.Excluir(taxaServico);

                Log.Debug("Taxa ou Serviço {TaxaServicoId} excluído com sucesso!", taxaServico.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<string> erros = new();

                string msgErro;

                if (ex.Message.Contains("FK"))
                {
                    msgErro = "Não é possível excluir essa taxa ou serviço, pois ela está sendo usada em outros lugares";
                }
                else
                {
                    msgErro = "Erro desconhecido. Falha ao tentar excluir Taxa ou Serviço.";
                }

                repositorioTaxaServico.DesfazerAlteracoes();

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxaServicoId}", taxaServico.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTaxaServico(TaxaServico taxaServico)
        {
            var resultadoValidacao = Validar(taxaServico);

            List<string> erros = new();

            if(resultadoValidacao != null)
            {
                erros.AddRange(resultadoValidacao.Errors.Select(e => e.Message));
            }

            if(NomeDuplicado(taxaServico))
            {
                erros.Add($"Já existe uma Taxa ou Serviço com o nome '{taxaServico.Nome}'");
            }

            foreach(string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(TaxaServico taxaServico)
        {
            TaxaServico taxaServicoEncontrado = repositorioTaxaServico.BuscarPorNome(taxaServico.Nome);

            if (taxaServicoEncontrado != null &&
                taxaServicoEncontrado.Id != taxaServico.Id &&
                taxaServicoEncontrado.Nome == taxaServico.Nome)
            {
                return true;
            }
            return false;
        }
    }
}