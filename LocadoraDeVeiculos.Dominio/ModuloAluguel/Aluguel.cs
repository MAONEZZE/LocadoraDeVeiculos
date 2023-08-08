using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System.Data;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Funcionario Funcionario { get; set; }

        public Cliente Cliente { get; set; }

        public Condutor Condutor { get; set; }

        public GrupoAutomovel GrupoAutomovel { get; set; }

        public Automovel Automovel { get; set; }

        public PlanoDeCobranca PlanoDeCobranca { get; set; }

        public int KMPercorrido { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucaoPrevista { get; set; }

        public DateTime DataDevolucao { get; set; }

        public Cupom Cupom { get; set; }

        public NivelCombustivelEnum NivelCombustivelAtual { get; set; }

        public List<TaxaServico> TaxasServicos { get; set; }

        public bool EstaAberto { get; set; }

        public Decimal ValorTotalPrevisto { get; set; }

        public Decimal ValorTotal { get; set; }

        public Aluguel()
        {
            this.TaxasServicos = new();
            this.NivelCombustivelAtual = NivelCombustivelEnum.Cheio;
            this.EstaAberto = true;
        }

        public Aluguel(Funcionario funcionario, Cliente cliente, Condutor condutor, GrupoAutomovel grupoAutomovel, Automovel automovel, PlanoDeCobranca planoDeCobranca, int kmAutomovelAtual, DateTime dataLocacao, DateTime dataDevolucaoPrevista, DateTime dataDevolucao, Cupom cupom, NivelCombustivelEnum nivelCombustivelAtual, List<TaxaServico> listaTaxaServico, bool estaAberto)
        {
            this.Funcionario = funcionario;
            this.Cliente = cliente;
            this.Condutor = condutor;
            this.GrupoAutomovel = grupoAutomovel;
            this.Automovel = automovel;
            this.PlanoDeCobranca = planoDeCobranca;
            this.KMPercorrido = kmAutomovelAtual;
            this.DataLocacao = dataLocacao;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
            this.DataDevolucao = dataDevolucao;
            this.Cupom = cupom;
            this.NivelCombustivelAtual = nivelCombustivelAtual;
            this.TaxasServicos = listaTaxaServico;
            this.EstaAberto = estaAberto;
        }

        public Aluguel(Guid id, Funcionario funcionario, Cliente cliente, Condutor condutor, GrupoAutomovel grupoAutomovel, Automovel automovel, PlanoDeCobranca planoDeCobranca, int kmAutomovelAtual, DateTime dataLocacao, DateTime dataDevolucaoPrevista, DateTime dataDevolucao, Cupom cupom, NivelCombustivelEnum nivelCombustivelAtual, List<TaxaServico> listaTaxaServico, bool estaAberto)
        {
            this.Id = id;
            this.Funcionario = funcionario;
            this.Cliente = cliente;
            this.Condutor = condutor;
            this.GrupoAutomovel = grupoAutomovel;
            this.Automovel = automovel;
            this.PlanoDeCobranca = planoDeCobranca;
            this.KMPercorrido = kmAutomovelAtual;
            this.DataLocacao = dataLocacao;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
            this.DataDevolucao = dataDevolucao;
            this.Cupom = cupom;
            this.NivelCombustivelAtual = nivelCombustivelAtual;
            this.TaxasServicos = listaTaxaServico;
            this.EstaAberto = estaAberto;
        }

        public override void AlterarInformacoes(Aluguel entidade)
        {
            Id = entidade.Id;
            Funcionario = entidade.Funcionario;
            Cliente = entidade.Cliente;
            Condutor = entidade.Condutor;
            GrupoAutomovel = entidade.GrupoAutomovel;
            Automovel = entidade.Automovel;
            PlanoDeCobranca = entidade.PlanoDeCobranca;
            DataLocacao = entidade.DataLocacao;
            DataDevolucao = entidade.DataDevolucao;
            Cupom = entidade.Cupom;
            TaxasServicos = entidade.TaxasServicos;
            EstaAberto = entidade.EstaAberto;
        }
    }
}
