using Application.DTOs;
using Application.Queries.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class ObterTodasMatriculasQueryHandler : IRequestHandler<ObterTodasMatriculasQuery, List<MatriculaDTO>>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public ObterTodasMatriculasQueryHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<List<MatriculaDTO>> Handle(ObterTodasMatriculasQuery query, CancellationToken cancellationToken)
        {
            var matriculas = await _matriculaRepository.GetAllAsync();
            return matriculas.Select(c => new MatriculaDTO
            {
                Id = c.Id,
                DataMatricula = c.DataMatricula,
                Status = c.Status,
                AlunoId = c.AlunoId,
                AlunoNome = c.Aluno?.Nome
            }).ToList();
        }
    }
}
