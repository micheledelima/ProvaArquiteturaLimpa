using Application.DTOs;
using Application.Queries.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class ObterMatriculaPorIdQueryHandler : IRequestHandler<ObterMatriculaPorIdQuery, MatriculaDTO>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public ObterMatriculaPorIdQueryHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<MatriculaDTO> Handle(ObterMatriculaPorIdQuery query, CancellationToken cancellationToken)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(query.Id);
            if (matricula == null)
                return null;

            return new MatriculaDTO
            {
                AlunoId = matricula.AlunoId,
                DataMatricula = matricula.DataMatricula,
                Status = matricula.Status,
                AlunoNome = matricula.Aluno.Nome
            };
        }
    }
}
