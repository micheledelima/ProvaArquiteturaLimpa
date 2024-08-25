using Application.Commands.Professor;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Professor
{
    public class AtualizarProfessorCommandHandler : IRequestHandler<AtualizarProfessorCommand, ProfessorDTO>
    {
        private readonly IProfessorRepository _professorRepository;

        public AtualizarProfessorCommandHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<ProfessorDTO> Handle(AtualizarProfessorCommand command, CancellationToken cancellationToken)
        {
            var professor = await _professorRepository.GetByIdAsync(command.Id);

            if (professor == null)
                return null;

            professor.Nome = command.Nome;
            professor.Email = command.Email;

            await _professorRepository.UpdateAsync(professor);

            return new ProfessorDTO
            {
                Nome = command.Nome,
                Email = command.Email
            };
        }
    }
}
