using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

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

            builder.Property(p => p.KMPercorrido)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.DataLocacao)
                .IsRequired();

            builder.Property(p => p.DataDevolucaoPrevista)
                .IsRequired();

            builder.Property(p => p.DataDevolucao)
                .IsRequired();

            builder.HasOne(p => p.Cupom)
                .WithMany()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.NivelCombustivelAtual)
                .IsRequired()
                .HasDefaultValue(NivelCombustivelEnum.Cheio);

            builder.HasMany(p => p.TaxasServicos)
                .WithMany()
                .UsingEntity(x => x.ToTable("TBAluguel_TBTaxaServico"));

            builder.Property(p => p.EstaAberto)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.ValorTotalPrevisto)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}
