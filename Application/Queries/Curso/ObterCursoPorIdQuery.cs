using Application.DTOs;
using MediatR;

namespace Application.Queries.Curso
{
    public class ObterCursoPorIdQuery : IRequest<CursoDTO>
    {
        public Guid Id { get; }

        public ObterCursoPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
