using MediatR;

namespace Application.Commands.Professor
{
    public class CriarProfessorCommand : IRequest<Guid>
    {
        public string Nome { get; }
        public string Email { get; }

        public CriarProfessorCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
