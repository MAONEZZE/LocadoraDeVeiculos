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

            builder.Property(c => c.TipoCliente).HasColumnType("varchar(250)").HasColumnName("Tipo de Cliente").IsRequired();

            builder.Ignore(c => c.Endereco);

            //builder.HasNoKey().Property(c => c.Endereco).IsRequired();

            //builder.Property(c => c.endereco.logradouro).HasColumnType("varchar(250)").HasColumnName("Logradouro").IsRequired();

            //builder.Property(c => c.endereco.bairro).HasColumnType("varchar(100)").HasColumnName("Bairro").IsRequired();

            //builder.Property(c => c.endereco.cidade).HasColumnType("varchar(30)").HasColumnName("Cidade").IsRequired();

            //builder.Property(c => c.endereco.estado).HasColumnType("varchar(30)").HasColumnName("Estado").IsRequired();

            //builder.Property(c => c.endereco.cep).HasColumnType("varchar(30)").HasColumnName("CEP").IsRequired();

            //builder.Property(c => c.endereco.numero).HasColumnName("Número").IsRequired();

            //builder.Property(c => c.endereco.complemento).HasColumnType("varchar(30)").HasColumnName("Complemento").IsRequired();
        }
    }
}
