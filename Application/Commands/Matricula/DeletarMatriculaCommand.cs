using MediatR;

namespace Application.Commands.Matricula
{
    public class DeletarMatriculaCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeletarMatriculaCommand(Guid id)
        {
            Id = id;
        }
    }
}
