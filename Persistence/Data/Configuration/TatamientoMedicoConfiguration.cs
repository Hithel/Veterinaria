

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class TatamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
        {
            public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
            {
                builder.ToTable("TratamientoMedicos");

                builder.Property(p => p.Dosis)
                .HasColumnName("Dosis")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
    
                builder.Property(p => p.FechaAdministracion)
                .HasColumnName("FechaAdministracion")
                .HasColumnType("date")
                .IsRequired();
                
                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.HasOne(p => p.Mascota)
                .WithMany(p => p.TatamientoMedicos)
                .HasForeignKey(p => p.IdMascotaFK);

                builder.HasOne(p => p.Medicamento)
                .WithMany(p => p.TratamientoMedicos)
                .HasForeignKey(p => p.IdMedicamentoFk);
            }
        }