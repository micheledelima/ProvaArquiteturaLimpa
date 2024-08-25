using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMatriculaRepository : IGenericRepository<Matricula>
    {
        Task<bool> PodeMatricularAlunoAsync(Guid cursoId, Guid alunoId);
    }
}