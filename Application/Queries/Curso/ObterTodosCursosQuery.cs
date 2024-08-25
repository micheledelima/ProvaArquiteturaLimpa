using Application.DTOs;
using MediatR;

namespace Application.Queries.Curso
{
    public class ObterTodosCursosQuery : IRequest<List<CursoDTO>>
    {
    }
}
