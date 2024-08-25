using Application.Commands.Curso;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Curso
{
    public class CadastrarCursoCommandHandler : IRequestHandler<CriarCursoCommand, Guid>
    {
        private readonly ICursoRepository _cursoRepository;

        public CadastrarCursoCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Guid> Handle(CriarCursoCommand command, CancellationToken cancellationToken)
        {
            var curso = new Domain.Entities.Curso()
            {
                Titulo = command.Titulo,
                Descricao = command.Descricao,
                ProfessorId = command.ProfessorId
            };

            await _cursoRepository.AddAsync(curso);

            return curso.Id;
        }
    }
}
