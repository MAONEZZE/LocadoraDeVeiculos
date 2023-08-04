using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.Infra.ModuloParceiro
{
    public class MapeadorParceiro : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("TBParceiro");

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.Nome).HasColumnType("varchar(250)").IsRequired();
        }
    }
}
