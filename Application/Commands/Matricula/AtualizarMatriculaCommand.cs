using Application.DTOs;
using MediatR;

namespace Application.Commands.Matricula
{
    public class AtualizarMatriculaCommand : IRequest<MatriculaDTO>
    {
        public Guid Id { get; }
        public string Status { get; }

        public AtualizarMatriculaCommand(Guid id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
