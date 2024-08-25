using Application.DTOs;
using MediatR;

namespace Application.Queries.Aluno
{
    public class ObterTodosAlunosQuery : IRequest<IEnumerable<AlunoDTO>>
    {
    }
}
