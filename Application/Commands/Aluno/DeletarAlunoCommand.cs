using Application.DTOs;
using MediatR;

namespace Application.Commands.Aluno
{
    public class DeletarAlunoCommand : IRequest<AlunoDTO>
    {
        public Guid Id { get; }

        public DeletarAlunoCommand(Guid id)
        {
            Id = id;
        }
    }
}
