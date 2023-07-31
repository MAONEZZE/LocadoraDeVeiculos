using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Infra.ModuloCupom
{
    public class MapeadorCupom : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("TBCupom");

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome).HasColumnType("varchar(250)").IsRequired();

            builder.Property(c=>c.DataValidade).IsRequired();

            builder.HasOne(c => c.Parceiro).WithMany().IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(c => c.EhValido);


        }
    }
}
