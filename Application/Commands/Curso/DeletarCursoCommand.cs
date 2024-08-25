using MediatR;

namespace Application.Commands.Curso
{
    public class DeletarCursoCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeletarCursoCommand(Guid id)
        {
            Id = id;
        }
    }
}
