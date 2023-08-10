using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Infra.ModuloAluguel
{
    public class RepositorioAluguel : RepositorioBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Aluguel aluguel)
        {
            var aluguelEncontrado = registros.SingleOrDefault(x => x.Id == aluguel.Id);

            if (aluguelEncontrado == null || aluguelEncontrado.Id == aluguel.Id)
            {
                return true;
            }

            return false;
        }

        public override List<Aluguel> SelecionarTodos()
        {
            return registros.Include(x => x.Funcionario)
                            .Include(x => x.Cliente)
                            .Include(x => x.Condutor)
                            .Include(x => x.GrupoAutomovel)
                            .Include(x => x.Automovel)
                            .Include(x => x.PlanoDeCobranca)
                            .Include(x => x.Cupom)
                            .Include(x => x.TaxasServicos)
                            .ToList();
        }

        public int ObterQuantidadeDeAlugueisAtivosCom(Object registro) => ObterQuantidadeDeAlugueisCom(registro, true);
        public int ObterQuantidadeDeAlugueisConcluidosCom(Object registro) => ObterQuantidadeDeAlugueisCom(registro, false);
        public int ObterQuantidadeDeAlugueisCom(Object registro,bool estaAberto)
        {
            if (registro is Funcionario funcionario)
            {
                return registros.Count(x => x.Funcionario.Id == funcionario.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is Cliente cliente)
            {
                return registros.Count(x => x.Cliente.Id == cliente.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is Condutor condutor)
            {
                return registros.Count(x => x.Condutor.Id == condutor.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is GrupoAutomovel grupoAutomovel)
            {
                return registros.Count(x => x.GrupoAutomovel.Id == grupoAutomovel.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is Automovel automovel)
            {
                return registros.Count(x => x.Automovel.Id == automovel.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is PlanoDeCobranca planoDeCobranca)
            {
                return registros.Count(x => x.PlanoDeCobranca.Id == planoDeCobranca.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is Cupom cupom)
            {
                return registros.Count(x => x.Cupom.Id == cupom.Id && x.EstaAberto == estaAberto);
            }
            else
            if (registro is TaxaServico taxasServicos)
            {
                return registros.Count(x => x.TaxasServicos.Contains(taxasServicos) && x.EstaAberto == estaAberto);
            }
            return 0;
        }
    }
}
