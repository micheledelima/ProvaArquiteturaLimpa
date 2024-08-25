using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Titulo)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Descricao)
                   .HasMaxLength(500); 

            builder.HasOne(c => c.Professor)
                   .WithMany(p => p.Cursos)
                   .HasForeignKey(c => c.ProfessorId);

            builder.HasMany(c => c.Matriculas)
                   .WithOne(m => m.Curso)
                   .HasForeignKey(m => m.CursoId);
        }
    }
}
