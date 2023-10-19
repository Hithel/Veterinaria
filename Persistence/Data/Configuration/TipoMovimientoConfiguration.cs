

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
        {
            public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
            {
                builder.ToTable("TipoMovimiento");

                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
    
            }
        }