using MediatR;

namespace Application.Commands.Aluno
{
    public class CadastrarAlunoCommand : IRequest<Guid>
    {
        public string Nome { get; }
        public string Endereco { get; }
        public string Email { get; }

        public CadastrarAlunoCommand(string nome, string endereco, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
        }
    }
}
