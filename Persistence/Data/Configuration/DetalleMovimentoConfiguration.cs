

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class DetalleMovimentoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
        {
            public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
            {
                builder.ToTable("DetalleMovimientos");
    
                builder.Property(p => p.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.PrecioUnitario)
                .HasColumnName("PrecioUnitario")
                .HasColumnType("double")
                .HasMaxLength(10)
                .IsRequired();

                builder.Property(p => p.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("date")
                .IsRequired();

                builder.HasOne(p => p.Medicamento)
                .WithMany(p => p.DetalleMovimientos)
                .HasForeignKey(p => p.IdMedicamentoFk);

                builder.HasOne(p => p.Movimiento)
                .WithMany(p => p.DetalleMovimientos)
                .HasForeignKey(p => p.IdMovimientoFK);
            }
        }