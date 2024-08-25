using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> PodeMatricularAlunoAsync(Guid cursoId, Guid alunoId)
        {
            var curso = await _context.Cursos.Include(c => c.Alunos).FirstOrDefaultAsync(c => c.Id == cursoId);
            return curso != null && curso.PodeAdicionarAluno();
        }
    }
}
