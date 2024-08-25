using Application.DTOs;
using Application.Queries.Professor;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Professor
{
    public class ObterTodosProfessoresQueryHandler : IRequestHandler<ObterTodosProfessoresQuery, List<ProfessorDTO>>
    {
        private readonly IProfessorRepository _professorRepository;

        public ObterTodosProfessoresQueryHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<List<ProfessorDTO>> Handle(ObterTodosProfessoresQuery query, CancellationToken cancellationToken)
        {
            var professores = await _professorRepository.GetAllAsync();
            return professores.Select(p => new ProfessorDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email
            }).ToList();
        }
    }
}
