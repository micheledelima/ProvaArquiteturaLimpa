using Application.Commands.Aluno;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Aluno
{
    public class DeletarAlunoCommandHandler : IRequestHandler<DeletarAlunoCommand, AlunoDTO>
    {
        private readonly IAlunoRepository _alunoRepository;

        public DeletarAlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoDTO> Handle(DeletarAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(command.Id);
            if (aluno == null)
                return null;

            await _alunoRepository.DeleteAsync(command.Id);
            return new AlunoDTO
            {
                Nome = aluno.Nome,
                Endereco = aluno.Endereco,
                Email = aluno.Email
            };
        }
    }
}
