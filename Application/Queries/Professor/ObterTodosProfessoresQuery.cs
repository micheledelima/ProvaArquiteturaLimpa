using Application.DTOs;
using MediatR;

namespace Application.Queries.Professor
{
    public class ObterTodosProfessoresQuery : IRequest<List<ProfessorDTO>>
    {
    }
}
