using Application.Commands.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class CadastrarMatriculaCommandHandler : IRequestHandler<CadastrarMatriculaCommand, Guid>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public CadastrarMatriculaCommandHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<Guid> Handle(CadastrarMatriculaCommand command, CancellationToken cancellationToken)
        {
            var matricula = new Domain.Entities.Matricula
            {
                DataMatricula = command.DataMatricula,
                Status = command.Status,
                AlunoId = command.AlunoId,
                CursoId = command.CursoId
            };

            await _matriculaRepository.AddAsync(matricula);

            return matricula.Id;
        }
    }
}
