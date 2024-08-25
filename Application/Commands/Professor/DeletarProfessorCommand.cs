using MediatR;

namespace Application.Commands.Professor
{
    public class DeletarProfessorCommand : IRequest<Unit>
    {
        public int Id { get; }

        public DeletarProfessorCommand(int id)
        {
            Id = id;
        }
    }
}
