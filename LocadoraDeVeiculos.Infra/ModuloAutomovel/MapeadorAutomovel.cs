using LocadoraDeVeiculos.Dominio.ModuloAutomovel;


namespace LocadoraDeVeiculos.Infra.ModuloAutomovel
{
    public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builder)
        {
            builder.ToTable("TBAutomovel");

            builder.Property(a=>a.Id).ValueGeneratedNever().IsRequired();

            builder.Property(a => a.Ano).IsRequired();

            builder.Property(a => a.Combustivel).IsRequired();

            builder.Property(a=>a.Cor).HasColumnType("varchar(50)").IsRequired();

            builder.Property(a=>a.Marca).HasColumnType("varchar(50)").IsRequired();

            builder.Property(a=>a.Modelo).HasColumnType("varchar(50)").IsRequired();

            builder.Property(a=>a.Placa).HasColumnType("varchar(10)").IsRequired();

            builder.Property(a => a.Quilometragem).IsRequired();

            builder.Property(a => a.CapacidadeDeCombustivel).IsRequired();

            builder.HasOne(a=>a.GrupoAutomovel).WithMany().IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(a => a.Foto, foto =>
            {
                foto.Property(f => f.NomeArquivo).IsRequired();
                foto.Property(f => f.ImagemBytes).IsRequired();
            });
        }
    }
}
