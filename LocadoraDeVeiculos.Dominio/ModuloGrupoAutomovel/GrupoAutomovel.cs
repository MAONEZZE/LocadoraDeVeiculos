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
    }
}
