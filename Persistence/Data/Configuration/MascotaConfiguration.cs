
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
        {
            public void Configure(EntityTypeBuilder<Mascota> builder)
            {
                builder.ToTable("Mascottas");

                builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

                builder.Property(p => p.FechaNacimineto)
                .HasColumnName("FechaNacimineto")
                .HasColumnType("date")
                .IsRequired();

                builder.HasOne(p => p.Propietario)
                .WithMany(p => p.Mascota)
                .HasForeignKey(p => p.IdPropietarioFk);

                builder.HasOne(p => p.Raza)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(p => p.IdRazaFK);

            }
        }