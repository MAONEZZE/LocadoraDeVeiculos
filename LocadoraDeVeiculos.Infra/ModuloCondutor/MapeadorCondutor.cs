using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");

            builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(c => c.Nome).HasColumnType("varchar(250)").HasColumnName("Nome").IsRequired();

            builder.Property(c => c.Telefone).HasColumnType("varchar(50)").HasColumnName("Telefone").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(50)").HasColumnName("Email").IsRequired();

            builder.Property(c => c.Documento).HasColumnType("varchar(50)").HasColumnName("CPF_do_Condutor").IsRequired();

            builder.Property(c => c.ValidadeCNH).HasColumnName("Validade_CNH").IsRequired();

            builder.Property(c => c.Cnh).HasColumnType("varchar(50)").HasColumnName("CNH").IsRequired();

            builder.HasOne(c => c.Cliente).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(c => c.EstaValido); //Ignore serve para não criar uma coluna na tabela de banco de dados


        }
    }
}
