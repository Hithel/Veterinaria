

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
        {


    public void Configure(EntityTypeBuilder<Movimiento> builder)
            {
                builder.ToTable("Movimientos");
    
                builder.Property(p => p.PrecioTotal)
                .HasColumnName("PrecioUnitario")
                .HasColumnType("double")
                .HasMaxLength(10)
                .IsRequired();

                builder.HasOne(p => p.TipoMovimientos)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(p => p.IdTipoMovimientoFK);
            }
        }