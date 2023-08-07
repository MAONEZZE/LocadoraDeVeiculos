using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.KmDisponivel).HasColumnName("Km_Disponivel").IsRequired();

            builder.Property(p => p.PrecoKm).HasColumnName("Preco_do_Km").IsRequired();

            builder.Property(p => p.PrecoDiaria).HasColumnName("Preco_da_Diaria").IsRequired();

            builder.Property(p => p.TipoPlano).HasColumnType("varchar(30)").HasColumnName("Tipo_de_Plano").IsRequired();

            builder.HasOne(p => p.GrupoAutomovel).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
