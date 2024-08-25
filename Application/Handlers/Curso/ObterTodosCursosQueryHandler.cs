using Application.DTOs;
using Application.Queries.Curso;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Curso
{
    public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, List<CursoDTO>>
    {
        private readonly ICursoRepository _cursoRepository;

        public ObterTodosCursosQueryHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoDTO>> Handle(ObterTodosCursosQuery query, CancellationToken cancellationToken)
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return cursos.Select(c => new CursoDTO
            {
                Id = c.Id,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                ProfessorId = c.ProfessorId
            }).ToList();
        }
    }
}
