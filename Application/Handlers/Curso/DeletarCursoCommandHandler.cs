using Application.Commands.Curso;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Curso
{
    public class DeletarCursoCommandHandler : IRequestHandler<DeletarCursoCommand, Unit>
    {
        private readonly ICursoRepository _cursoRepository;

        public DeletarCursoCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Unit> Handle(DeletarCursoCommand command, CancellationToken cancellationToken)
        {
            await _cursoRepository.DeleteAsync(command.Id);
            return Unit.Value;
        }
    }
}
