

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CitasConfiguration : IEntityTypeConfiguration<Citas>
        {
            public void Configure(EntityTypeBuilder<Citas> builder)
            {
                builder.ToTable("Citas");
    
                builder.Property(p => p.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("date")
                .IsRequired();

                builder.Property(p => p.Motivo)
                .HasColumnName("motivo")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.HasOne(p => p.User)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.IdUserFK);

                builder.HasOne(p => p.Mascota)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.IdMascotaFk);

                builder.HasOne(p => p.Veterinario)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.IdVeterinarioFK);
            }
        }