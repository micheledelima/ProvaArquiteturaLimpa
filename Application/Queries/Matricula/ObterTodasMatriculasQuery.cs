using Application.DTOs;
using MediatR;

namespace Application.Queries.Matricula
{
    public class ObterTodasMatriculasQuery : IRequest<List<MatriculaDTO>>
    {
    }
}
