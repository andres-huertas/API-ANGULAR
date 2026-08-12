using ApiAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAngular.Infrastructure.Data.Configurations;
public class CursoPrecioConfiguration : IEntityTypeConfiguration<CursoPrecio>
{
    public void Configure(EntityTypeBuilder<CursoPrecio> builder)
    {
        builder.ToTable("Curso_Precio");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.IdCurso)
               .IsRequired();

        builder.Property(x => x.Precio)
               .HasColumnType("decimal(10,2)");

        builder.Property(x => x.FechaInicio)
               .IsRequired();

        builder.Property(x => x.FechaFin);

        builder.HasIndex(x => x.IdCurso)
               .HasDatabaseName("IX_CursoPrecio_Curso");

        builder.HasOne(x => x.Curso)
                .WithMany(x => x.Precios)
                .HasForeignKey(x => x.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);

         builder.HasIndex(x => x.IdCurso)
               .HasDatabaseName("IX_CursoPrecio_Curso");
    }
}