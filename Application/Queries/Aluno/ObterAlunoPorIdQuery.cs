using Application.DTOs;
using MediatR;

namespace Application.Queries.Aluno
{
    public class ObterAlunoPorIdQuery : IRequest<AlunoDTO>
    {
        public Guid Id { get; }

        public ObterAlunoPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
