using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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

        private IRepositorioAutomovel repositorioAutomovel;

        private IRepositorioCliente repositorioCliente;

        private IContextoPersistencia contexto;

        private IGeradorEmail geradorEmail;

        private IGeradorPdf geradorPdf;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel,
                              IRepositorioPrecoCombustivel repositorioPrecoCombustivel,
                              IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca,
                              IRepositorioAutomovel repositorioAutomovel,
                              IRepositorioCliente repositorioCliente,
                              IGeradorEmail geradorEmail,
                              IGeradorPdf geradorPdf,
                              IContextoPersistencia contexto
            )
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioPrecoCombustivel = repositorioPrecoCombustivel;
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioCliente = repositorioCliente;
            this.geradorEmail = geradorEmail;
            this.geradorPdf = geradorPdf;
            this.contexto = contexto;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir Aluguel... {@aluguel}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count > 0)
            {
                //Log.Debug("Tentando inserir Aluguel... {@aluguel}", aluguel);

                return Result.Fail(erros);
            }

            try
            {
                aluguel.ValorTotalPrevisto = CalcularValor(aluguel, false);

                if(aluguel.Cupom != null)
                {
                    aluguel.Cliente.AdicionarCupom(aluguel.Cupom);

                    repositorioCliente.Editar(aluguel.Cliente);
                }

                repositorioAluguel.Inserir(aluguel);

                EnviarEmail(aluguel);

                contexto.GravarDados();

                Log.Debug("Aluguel {AluguelId} inserido com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar inserir Aluguel.";

                contexto.DesfazerAlteracoes();

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
                if (aluguel.EstaAberto == false && aluguel.KMPercorrido > 0)
                {
                    aluguel.ValorTotal = CalcularValor(aluguel, true);

                    aluguel.Automovel.AtualizarQuilometragem(aluguel.KMPercorrido);

                    repositorioAutomovel.Editar(aluguel.Automovel);
                }
                else
                {
                    aluguel.ValorTotalPrevisto = CalcularValor(aluguel,false);
                }

                repositorioAluguel.Editar(aluguel);

                

                contexto.GravarDados();

                Log.Debug("Aluguel {AluguelId} editado com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Erro desconhecido. Falha ao tentar editar Aluguel.";

                contexto.DesfazerAlteracoes();

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

                contexto.GravarDados();

                Log.Debug("Aluguel {AluguelId} excluído com sucesso!", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                List<String> erros = new();

                string msgErro = "Erro desconhecido. Falha ao tentar excluir Aluguel.";

                contexto.DesfazerAlteracoes();

                Log.Error(ex, msgErro + " {aluguelId}", aluguel.Id);

                erros.Add(msgErro);

                return Result.Fail(erros);
            }
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

        public Decimal CalcularValor(DateTime dataLocacao, 
                                     DateTime dataDevolucaoPrevista, 
                                     DateTime dataDevolucao,
                                     NivelCombustivelEnum nivelCombustivelAtual,
                                     HashSet<TaxaServico> taxasServicos = null, 
                                     PlanoDeCobranca planoDeCobranca = null,
                                     Automovel automovel = null,
                                     int KMPercorrido = 1,
                                     Cupom cupom = null,
                                     bool ehDevolucao = false
                                     )
        {
            Decimal valorTotal = 0;
            int diasUsados = 0;

            if (ehDevolucao)
            {
                diasUsados = (dataLocacao - dataDevolucao).Days;
            }
            else
            {
                diasUsados = (dataDevolucaoPrevista - dataLocacao).Days;
            }

            if (diasUsados == 0)
            {
                diasUsados = 1;
            }

            foreach (TaxaServico taxaServico in taxasServicos)
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

            if (planoDeCobranca != null)
            {
                valorTotal += planoDeCobranca.CalculoTotalPreco(KMPercorrido, diasUsados);
            }


            if (automovel != null)
            {
                PrecoCombustivel precoCombustivel = repositorioPrecoCombustivel.Buscar();
                valorTotal += precoCombustivel.CalcularValorReposicaoCombustivel(automovel, nivelCombustivelAtual);
            }

            if (cupom != null)
            {
                valorTotal -= cupom.Valor;
            }

            if (dataDevolucao.Date > dataDevolucaoPrevista.Date)
            {
                int diasAtraso = (dataDevolucao - dataDevolucaoPrevista).Days;

                valorTotal += valorTotal * 0.1m;

                valorTotal += diasAtraso * 50;
            }

            return valorTotal;
        }

        public Decimal CalcularValor(Aluguel aluguel,bool ehDevolucao = false)
        {
            return CalcularValor(aluguel.DataLocacao, aluguel.DataDevolucaoPrevista, aluguel.DataDevolucao, aluguel.NivelCombustivelAtual, aluguel.TaxasServicos, aluguel.PlanoDeCobranca, aluguel.Automovel, aluguel.KMPercorrido, aluguel.Cupom, ehDevolucao);
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
