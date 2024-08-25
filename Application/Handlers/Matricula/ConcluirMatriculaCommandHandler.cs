using Application.Commands.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class ConcluirMatriculaCommandHandler : IRequestHandler<ConcluirMatriculaCommand, bool>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public ConcluirMatriculaCommandHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<bool> Handle(ConcluirMatriculaCommand request, CancellationToken cancellationToken)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(request.MatriculaId);
            if (matricula == null || !matricula.PodeConcluir())
            {
                return false;
            }

            matricula.Status = "Concluída";
            await _matriculaRepository.UpdateAsync(matricula);
            return true;
        }
    }
}
