using Application.DTOs;
using MediatR;

namespace Application.Commands.Aluno
{
    public class AtualizarAlunoCommand : IRequest<AlunoDTO>
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Endereco { get; }
        public string Email { get; }

        public AtualizarAlunoCommand(Guid id, string nome, string endereco, string email)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Email = email;
        }
    }
}
