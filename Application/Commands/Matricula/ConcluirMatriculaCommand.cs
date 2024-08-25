using MediatR;

namespace Application.Commands.Matricula
{
    public class ConcluirMatriculaCommand : IRequest<bool>
    {
        public Guid MatriculaId { get; set; }

        public ConcluirMatriculaCommand(Guid matriculaId)
        {
            MatriculaId = matriculaId;
        }
    }
}
