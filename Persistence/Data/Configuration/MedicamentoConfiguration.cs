

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
        {
            public void Configure(EntityTypeBuilder<Medicamento> builder)
            {
                builder.ToTable("Medicamentos");
    
                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.Property(p => p.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Precio)
                .HasColumnName("Precio")
                .HasColumnType("double")
                .HasMaxLength(10)
                .IsRequired();

                builder.HasOne(p => p.Laboratorio)
                .WithMany(p => p.Medicamentos)
                .HasForeignKey(p => p.IdLaboratorioFk);

                builder
                .HasMany(p => p.Proveedores) /* TipoPresentacion */
                .WithMany(r => r.Medicamentos)
                .UsingEntity<MedicamentoProveedor>(

                    j => j
                    .HasOne(et => et.Proveedor)
                    .WithMany(et => et.MedicamentoProveedores)
                    .HasForeignKey(el => el.IdProveedorFk),

                    j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(ut => ut.IdMedicamentoFk),
                    
                    j =>
                    {
                        j.ToTable("MedicamentoProveedores");
                        j.HasKey(t => new { t.IdMedicamentoFk, t.IdProveedorFk });

                    });
            }
        }