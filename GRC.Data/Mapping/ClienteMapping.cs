using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRC.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GRC.Data.Mapping
{
    public class ClienteMapping: IEntityTypeConfiguration<Cliente>
    {
        public ClienteMapping() { }
      
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Endereco)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(10)");

            builder.ToTable("Clientes");

        }
    }
}
