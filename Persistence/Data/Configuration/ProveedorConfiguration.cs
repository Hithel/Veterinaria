

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
        {
            public void Configure(EntityTypeBuilder<Proveedor> builder)
            {
                builder.ToTable("Proveedores");
    
                builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.Property(p => p.Direccion)
                .HasColumnName("Direccion")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.Telefono)
                .HasColumnName("telefono")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            }
        }