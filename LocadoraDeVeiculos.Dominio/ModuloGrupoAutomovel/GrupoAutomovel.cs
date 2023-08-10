namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Nome { get; set; } = string.Empty;
     
        public GrupoAutomovel() { }
     
        public override void AlterarInformacoes(GrupoAutomovel entidade)
        {
           Nome = entidade.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is GrupoAutomovel automovel &&
                   Id== automovel.Id &&
                   Nome == automovel.Nome;
        }
    }
}
