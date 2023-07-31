using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome).HasColumnType("varchar(250)").IsRequired();

            builder.Property(c => c.Telefone).HasColumnType("varchar(250)").IsRequired();

            builder.Property(c => c.Email).HasColumnType("varchar(250)").IsRequired();
        }
    }
}
