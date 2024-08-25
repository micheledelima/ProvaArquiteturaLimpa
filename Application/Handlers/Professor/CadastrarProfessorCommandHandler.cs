using Application.Commands.Professor;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Professor
{
    public class CadastrarProfessorCommandHandler : IRequestHandler<CriarProfessorCommand, Guid>
    {
        private readonly IProfessorRepository _professorRepository;

        public CadastrarProfessorCommandHandler(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<Guid> Handle(CriarProfessorCommand command, CancellationToken cancellationToken)
        {
            var professor = new Domain.Entities.Professor
            {
                Nome = command.Nome,
                Email = command.Email
            };

            await _professorRepository.AddAsync(professor);

            return professor.Id;
        }
    }
}
