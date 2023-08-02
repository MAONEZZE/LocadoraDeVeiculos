using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("TBCliente");

            builder.Property(c => c.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(c => c.Nome).HasColumnType("varchar(250)").HasColumnName("Nome").IsRequired();

            builder.Property(c => c.Telefone).HasColumnType("varchar(50)").HasColumnName("Telefone").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(50)").HasColumnName("Email").IsRequired();

            builder.Property(c => c.Documento).HasColumnType("varchar(50)").HasColumnName("Documento do Cliente").IsRequired();

            builder.Property(c => c.TipoCliente).HasColumnType("varchar(30)").HasColumnName("Tipo de Cliente").IsRequired();

            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Logradouro).HasColumnType("varchar(250)").HasColumnName("Logradouro").IsRequired();
                endereco.Property(e => e.Bairro).HasColumnType("varchar(100)").HasColumnName("Bairro").IsRequired();
                endereco.Property(e => e.Cidade).HasColumnType("varchar(30)").HasColumnName("Cidade").IsRequired();
                endereco.Property(e => e.Estado).HasColumnType("varchar(30)").HasColumnName("Estado").IsRequired();
                endereco.Property(e => e.Cep).HasColumnType("varchar(30)").HasColumnName("CEP").IsRequired();
                endereco.Property(e => e.Numero).HasColumnName("Número").IsRequired();
                endereco.Property(e => e.Complemento).HasColumnType("varchar(30)").HasColumnName("Complemento").IsRequired();
            });
        }
    }
}
