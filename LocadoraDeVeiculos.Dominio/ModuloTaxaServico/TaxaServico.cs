namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase<TaxaServico>
    {
        public string Nome { get; set; }

        public int Preco { get; set; }

        public EnumTipoCalculo TipoCalculo { get; set; }

        public TaxaServico()
        {
        }

        public TaxaServico(Guid id, string nome, int preco, EnumTipoCalculo tipoCalculo)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            TipoCalculo = tipoCalculo;
        }

        public TaxaServico(string nome, int preco, EnumTipoCalculo tipoCalculo)
        {
            Nome = nome;
            Preco = preco;
            TipoCalculo = tipoCalculo;
        }

        public override void AlterarInformacoes(TaxaServico entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Preco = entidade.Preco;
            TipoCalculo = entidade.TipoCalculo;
        }

        public override bool Equals(object? obj)
        {
            return obj is TaxaServico servico
                   && Id == servico.Id
                   && Nome == servico.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
