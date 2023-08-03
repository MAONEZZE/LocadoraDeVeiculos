using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.Infra.ModuloTaxaServico
{
    public class MapeadorTaxaServico : IEntityTypeConfiguration<TaxaServico>
    {
        public void Configure(EntityTypeBuilder<TaxaServico> builder)
        {
            builder.ToTable("TBTaxaServico");
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.TipoCalculo).IsRequired();
        }
    }
}
