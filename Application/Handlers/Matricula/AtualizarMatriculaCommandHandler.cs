using Application.Commands.Matricula;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class AtualizarMatriculaCommandHandler : IRequestHandler<AtualizarMatriculaCommand, MatriculaDTO>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public AtualizarMatriculaCommandHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<MatriculaDTO> Handle(AtualizarMatriculaCommand command, CancellationToken cancellationToken)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(command.Id);

            if (matricula == null)
                return null;

            matricula.Status = command.Status;

            await _matriculaRepository.UpdateAsync(matricula);

            return new MatriculaDTO()
            {
                Status = matricula.Status,
            };
        }
    }
}
