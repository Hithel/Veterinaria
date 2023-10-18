
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
        {
            public void Configure(EntityTypeBuilder<Veterinario> builder)
            {
                builder.ToTable("Veterinarios");

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
                .HasColumnType("int")
                .HasMaxLength(10)
                .IsRequired();

                builder.Property(p => p.Especialidad)
                .HasColumnName("especialidad")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            }
        }