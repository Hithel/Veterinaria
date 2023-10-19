

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class PropietarioConfigurationc : IEntityTypeConfiguration<Propietario>
        {
            public void Configure(EntityTypeBuilder<Propietario> builder)
            {
                builder.ToTable("Propietarios");
    
                builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.Property(p => p.Email)
                .HasColumnName("Email")
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