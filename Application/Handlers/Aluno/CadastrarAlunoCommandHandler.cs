using Application.Commands.Aluno;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class CadastrarAlunoCommandHandler : IRequestHandler<CadastrarAlunoCommand, Guid>
    {
        private readonly IAlunoRepository _alunoRepository;

        public CadastrarAlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Guid> Handle(CadastrarAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = new Domain.Entities.Aluno
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Endereco = command.Endereco,
                Email = command.Email
            };

            await _alunoRepository.AddAsync(aluno);

            return aluno.Id;
        }
    }
}
