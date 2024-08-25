using Application.Commands.Matricula;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Matricula
{
    public class MatricularAlunoCommandHandler : IRequestHandler<MatricularAlunoCommand, bool>
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ICursoRepository _cursoRepository;

        public MatricularAlunoCommandHandler(IMatriculaRepository matriculaRepository, ICursoRepository cursoRepository)
        {
            _matriculaRepository = matriculaRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> Handle(MatricularAlunoCommand request, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.GetByIdAsync(request.CursoId);
            if (curso == null || !curso.PodeAdicionarAluno())
            {
                return false; // Não pode matricular
            }

            var matricula = new Domain.Entities.Matricula
            {
                Id = Guid.NewGuid(),
                AlunoId = request.AlunoId,
                CursoId = request.CursoId,
                DataMatricula = DateTime.Now,
                Status = "Ativa"
            };

            await _matriculaRepository.AddAsync(matricula);
            return true;
        }
    }
}
