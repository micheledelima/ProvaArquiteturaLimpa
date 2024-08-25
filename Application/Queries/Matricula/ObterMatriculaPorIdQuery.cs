using Application.DTOs;
using MediatR;

namespace Application.Queries.Matricula
{
    public class ObterMatriculaPorIdQuery : IRequest<MatriculaDTO>
    {
        public Guid Id { get; }

        public ObterMatriculaPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
