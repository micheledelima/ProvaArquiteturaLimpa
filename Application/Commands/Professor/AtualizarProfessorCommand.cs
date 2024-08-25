using Application.DTOs;
using MediatR;

namespace Application.Commands.Professor
{
    public class AtualizarProfessorCommand : IRequest<ProfessorDTO>
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }

        public AtualizarProfessorCommand(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
