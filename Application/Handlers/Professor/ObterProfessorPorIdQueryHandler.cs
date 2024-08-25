using Application.DTOs;
using Application.Queries.Professor;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Professor
{
    public class ObterProfessorPorIdQueryHandler : IRequestHandler<ObterProfessorPorIdQuery, ProfessorDTO>
    {
        private readonly IProfessorRepository _professorRepository;

        public ObterProfessorPorIdQueryHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ProfessorDTO> Handle(ObterProfessorPorIdQuery query, CancellationToken cancellationToken)
        {
            var professor = await _professorRepository.GetByIdAsync(query.Id);
            if (professor == null)
                return null;

            return new ProfessorDTO
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Email = professor.Email
            };
        }
    }
}
