using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoAutomovel
{
    public class MapeadorGrupoAutomovel : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> builder)
        {
            builder.ToTable("TBGrupoAutomovel");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Nome).HasColumnType("varchar(250)").IsRequired();
        }
    }
}
