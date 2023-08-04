using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.Infra.ModuloAluguel
{
    public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("TBAluguel");

            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            builder.HasOne(p => p.Funcionario)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Condutor)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.GrupoAutomovel)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Automovel)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.PlanoDeCobranca)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.KmAutomovelAtual).IsRequired();

            builder.Property(p => p.DataLocacao).IsRequired();

            builder.Property(p => p.DataDevolucaoPrevista).IsRequired();

            builder.Property(p => p.DataDevolucao).IsRequired();

            builder.HasOne(p => p.Cupom)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.TaxasServicos)
                .WithMany()
                .UsingEntity(x => x.ToTable("TBAluguel_TBTaxaServico"));

            builder.Property(p => p.EstaAberto)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.ValorParcial)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .IsRequired();
        }
    }
}
