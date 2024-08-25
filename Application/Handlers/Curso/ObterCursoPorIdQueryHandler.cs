using Application.DTOs;
using Application.Queries.Curso;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Curso
{
    public class ObterCursoPorIdQueryHandler : IRequestHandler<ObterCursoPorIdQuery, CursoDTO>
    {
        private readonly ICursoRepository _cursoRepository;

        public ObterCursoPorIdQueryHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoDTO> Handle(ObterCursoPorIdQuery query, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.GetByIdAsync(query.Id);
            if (curso == null)
                return null;

            return new CursoDTO
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descricao = curso.Descricao,
                ProfessorId = curso.ProfessorId
            };
        }
    }
}
