using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.ModuloAutomovel;

namespace LocadoraDeVeiculos.Servico.ModuloAluguel
{
    public class ServicoAluguel : ServicoBase<Aluguel, ValidadorAluguel>
    {
        private IRepositorioAluguel repositorioAluguel;

        private IRepositorioPrecoCombustivel repositorioPrecoCombustivel;

        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        private IGeradorEmail geradorEmail;

        private IGeradorPdf geradorPdf;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel,
                              IRepositorioPrecoCombustivel repositorioPrecoCombustivel,
                              IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca,
                              IGeradorEmail geradorEmail,
                              IGeradorPdf geradorPdf)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioPrecoCombustivel = repositorioPrecoCombustivel;
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.geradorEmail = geradorEmail;
            this.geradorPdf = geradorPdf;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir Aluguel... {@aluguel}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Inserir(aluguel);

                EnviarEmail(aluguel);

                Log.Debug("Aluguel {AluguelId} inserido com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar inserir Aluguel.";

                Log.Error(ex, msgErro + " {aluguel}", aluguel);

                return Result.Fail(msgErro);
            }
        }


        public Result Editar(Aluguel aluguel)
        {
            Log.Debug($"Tentando editar Aluguel... {aluguel}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count > 0)
            {
                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Editar(aluguel);

                Log.Debug("Aluguel {AluguelId} editado com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar editar Aluguel.";

                Log.Error(ex, msgErro + " {aluguel}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug($"Tentando excluir Aluguel... {aluguel}", aluguel);

            try
            {
                bool aluguelExiste = repositorioAluguel.Existe(aluguel);

                if (aluguelExiste == false)
                {

                    Log.Warning("Aluguel {AluguelId} não encontrado!", aluguel.Id);

                    return Result.Fail("Aluguel não existe!");
                }

                repositorioAluguel.Excluir(aluguel);

                Log.Debug("Aluguel {AluguelId} excluído com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<String> erros = new();

                string msgErro = "Erro desconhecido. Falha ao tentar excluir Aluguel.";

                Log.Error(ex, msgErro + " {aluguelId}", aluguel.Id);

                erros.Add(msgErro);

                return Result.Fail(erros);
            }
        }
        public Result DevolverAutomovel(Aluguel aluguel)
        {
            Result resultado =  Editar(aluguel);
            if(resultado.IsFailed)
            {
                return resultado;
            }


            return Result.Ok();
        }
        public Result ConfigurarPrecoCombustiveis(PrecoCombustivel precos)
        {
            Log.Debug($"Tentando atualizar preços combustíves... {precos}", precos);

            var result = precos.Validar();

            if (result.IsFailed)
            {
                Log.Error("Não foi possivel atualizar os preços dos combustiveis");

                return Result.Fail(result.Reasons.Select(i => i.Message));
            }

            try
            {
                repositorioPrecoCombustivel.Atualizar(precos);

                Log.Debug($"Preços dos combustiveis atualizado com sucesso... {precos}", precos);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"Falha ao tentar atualizar os Preços dos combustiveis...\n{ex.Message} {precos}", precos);

                return Result.Fail(result.Reasons.Select(i => i.Message));
            }
        }


        public Result EnviarEmail(Aluguel aluguel)
        {
            Log.Debug($"Tentando enviar email...{aluguel}", aluguel);

            var anexo = geradorPdf.GerarPdfEmail(aluguel);

            if (anexo == null)
            {
                string msg = "Falha ao gerar PDF";

                Log.Error(msg);

                return Result.Fail(msg);
            }

            var statusEnvio = geradorEmail.EnviarEmail(aluguel, anexo);

            if (statusEnvio.IsFailed)
            {
                Log.Error("Falha ao tentar enviar email {aluguel}", aluguel);

                Result.Fail(statusEnvio.Reasons.Select(i => i.Message));
            }

            Log.Debug("Email enviado com sucesso {aluguel}", aluguel);

            return Result.Ok().WithSuccess("Email enviado com sucesso");

        }

        public PrecoCombustivel ObterConfiguracoesAtuais()
        {
            return repositorioPrecoCombustivel.Buscar();
        }

        public Decimal CalcularValorTotalPrevisto(Aluguel aluguel)
        {
            Decimal valorTotalPrevisto = 0;

            int previsaoDiasLocado = (aluguel.DataDevolucaoPrevista - aluguel.DataLocacao).Days;

            foreach (TaxaServico taxaServico in aluguel.TaxasServicos)
            {
                if (taxaServico.TipoCalculo == EnumTipoCalculo.Diario)
                {
                    valorTotalPrevisto += taxaServico.Preco * previsaoDiasLocado;
                }
                else if (taxaServico.TipoCalculo == EnumTipoCalculo.Fixo)
                {
                    valorTotalPrevisto += taxaServico.Preco;
                }
            }
            if (aluguel.PlanoDeCobranca != null)
            {
                valorTotalPrevisto += aluguel.PlanoDeCobranca.CalculoTotalPreco(0, previsaoDiasLocado);
            }

            if (aluguel.Cupom != null)
            {
                valorTotalPrevisto -= aluguel.Cupom.Valor;
            }

            aluguel.ValorTotalPrevisto = valorTotalPrevisto;

            return valorTotalPrevisto;
        }

        public Decimal CalcularValorTotal(Aluguel aluguel)
        {
            Decimal valorTotal = 0;

            int diasUsados = (aluguel.DataLocacao - aluguel.DataDevolucao).Days;

            foreach (TaxaServico taxaServico in aluguel.TaxasServicos)
            {
                if (taxaServico.TipoCalculo == EnumTipoCalculo.Diario)
                {
                    valorTotal += taxaServico.Preco * diasUsados;
                }
                else if (taxaServico.TipoCalculo == EnumTipoCalculo.Fixo)
                {
                    valorTotal += taxaServico.Preco;
                }
            }

            if (aluguel.PlanoDeCobranca != null)
            {
                valorTotal += aluguel.PlanoDeCobranca.CalculoTotalPreco(aluguel.KMPercorrido, diasUsados);
            }



            if (aluguel.Automovel != null && aluguel.KMPercorrido > 0)
            {
                PrecoCombustivel precoCombustivel = repositorioPrecoCombustivel.Buscar();
                valorTotal += precoCombustivel.CalcularValorReposicaoCombustivel(aluguel.Automovel, aluguel.NivelCombustivelAtual);
            }

            if (aluguel.Cupom != null)
            {
                valorTotal -= aluguel.Cupom.Valor;
            }

            if (aluguel.DataDevolucao.Day > aluguel.DataDevolucaoPrevista.Day)
            {
                int diasAtraso = (aluguel.DataDevolucao - aluguel.DataDevolucaoPrevista).Days;

                valorTotal += valorTotal * 0.1m;

                valorTotal += diasAtraso * 50;
            }

            aluguel.ValorTotal = valorTotal;

            return valorTotal;
        }

        private List<String> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = Validar(aluguel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
            {
                erros.AddRange(resultadoValidacao.Errors.Select(e => e.Message));
            }

            return erros;
        }
    }
}
