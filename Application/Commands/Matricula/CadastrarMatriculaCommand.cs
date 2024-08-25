using MediatR;

namespace Application.Commands.Matricula
{
    public class CadastrarMatriculaCommand : IRequest<Guid>
    {
        public DateTime DataMatricula { get; }
        public string Status { get; }
        public Guid AlunoId { get; }
        public Guid CursoId { get; }

        public CadastrarMatriculaCommand(DateTime dataMatricula, string status, Guid alunoId, Guid cursoId)
        {
            DataMatricula = dataMatricula;
            Status = status;
            AlunoId = alunoId;
            CursoId = cursoId;
        }
    }
}
