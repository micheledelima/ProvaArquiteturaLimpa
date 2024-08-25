using Application.DTOs;
using MediatR;

namespace Application.Commands.Curso
{
    public class AtualizarCursoCommand : IRequest<CursoDTO>
    {
        public Guid Id { get; }
        public string Titulo { get; }
        public string Descricao { get; }
        public Guid ProfessorId { get; }

        public AtualizarCursoCommand(Guid id, string titulo, string descricao, Guid professorId)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            ProfessorId = professorId;
        }
    }
}
