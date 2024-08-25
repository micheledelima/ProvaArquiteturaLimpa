using Application.Commands.Curso;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Curso
{
    public class AtualizarCursoCommandHandler : IRequestHandler<AtualizarCursoCommand, CursoDTO>
    {
        private readonly ICursoRepository _cursoRepository;

        public AtualizarCursoCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoDTO> Handle(AtualizarCursoCommand command, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.GetByIdAsync(command.Id);
            if (curso == null)
                return null;

            curso.Descricao = command.Descricao;
            curso.Titulo = command.Titulo;
            curso.Professor.Id = command.ProfessorId;

            await _cursoRepository.UpdateAsync(curso);

            return new CursoDTO
            {
                Descricao = command.Descricao,
                Titulo = command.Titulo,
                ProfessorId = command.ProfessorId
            };
        }
    }
}
