using Application.Commands.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class DeletarMatriculaCommandHandler : IRequestHandler<DeletarMatriculaCommand, Unit>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public DeletarMatriculaCommandHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<Unit> Handle(DeletarMatriculaCommand command, CancellationToken cancellationToken)
        {
            await _matriculaRepository.DeleteAsync(command.Id);
            return Unit.Value;
        }
    }
}
