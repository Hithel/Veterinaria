

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
        {
            public void Configure(EntityTypeBuilder<Especie> builder)
            {
                builder.ToTable("especies");

                builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            }
        }