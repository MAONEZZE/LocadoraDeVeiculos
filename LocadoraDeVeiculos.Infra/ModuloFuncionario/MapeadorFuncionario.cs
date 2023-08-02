using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(p => p.DataAdmissao).IsRequired();
            builder.Property(p => p.Salario).IsRequired();
        }
    }
}
