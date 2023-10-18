

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
        {
            public void Configure(EntityTypeBuilder<Laboratorio> builder)
            {
                builder.ToTable("Laboratorios");
    
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
                .HasColumnType("int")
                .HasMaxLength(10)
                .IsRequired();
            }
        }