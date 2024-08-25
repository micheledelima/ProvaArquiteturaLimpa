using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataBase.Mappings
{
    public class MatriculaMap : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.DataMatricula)
                   .IsRequired();

            builder.Property(m => m.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(m => m.Aluno)
                   .WithMany(a => a.Matriculas)
                   .HasForeignKey(m => m.AlunoId);

            builder.HasOne(m => m.Curso)
                   .WithMany(c => c.Matriculas)
                   .HasForeignKey(m => m.CursoId);
        }
    }
}
