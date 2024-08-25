using MediatR;

namespace Application.Commands.Matricula
{
    public class MatricularAlunoCommand : IRequest<bool>
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }

        public MatricularAlunoCommand(Guid alunoId, Guid cursoId)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
        }
    }
}
