using ApiAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAngular.Infrastructure.Data.Configurations;
public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Curso");
        
        builder.HasKey(c => c.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Descripcion)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.DuracionHoras)
               .IsRequired();

        builder.Property(x => x.FlagActivo)
               .IsRequired();

        builder.Property(x => x.FechaCreacion)
               .IsRequired();

        builder.Property(x => x.FechaModificacion);

        builder.HasMany(x => x.Precios)
               .WithOne()
               .HasForeignKey(x => x.IdCurso);

        builder.HasIndex(x => x.Descripcion)
               .HasDatabaseName("IX_Curso_Descripcion");
    }
}