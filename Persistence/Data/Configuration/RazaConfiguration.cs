
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class RazaConfiguration : IEntityTypeConfiguration<Raza>
        {
            public void Configure(EntityTypeBuilder<Raza> builder)
            {
                builder.ToTable("Razas");
    
                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.HasOne(p => p.Especie)
                .WithMany(p => p.Razas)
                .HasForeignKey(p => p.IdEspecieFK);
            }
        }