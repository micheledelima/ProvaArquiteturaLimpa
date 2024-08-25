using MediatR;

namespace Application.Commands.Curso
{
    public class CriarCursoCommand : IRequest<Guid>
    {
        public string Titulo { get; }
        public string Descricao { get; }
        public Guid ProfessorId { get; }

        public CriarCursoCommand(string titulo, string descricao, Guid professorId)
        {
            Titulo = titulo;
            Descricao = descricao;
            ProfessorId = professorId;
        }
    }
}
