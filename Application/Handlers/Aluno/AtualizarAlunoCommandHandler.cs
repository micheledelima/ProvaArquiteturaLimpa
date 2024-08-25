using Application.Commands.Aluno;
using Application.DTOs;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Aluno
{
    public class AtualizarAlunoCommandHandler : IRequestHandler<AtualizarAlunoCommand, AlunoDTO>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AtualizarAlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoDTO> Handle(AtualizarAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(command.Id);
            if (aluno == null)
            {
                return null;
            }

            aluno.Nome = command.Nome;
            aluno.Endereco = command.Endereco;
            aluno.Email = command.Email;
            await _alunoRepository.UpdateAsync(aluno);

            return new AlunoDTO
            {
                Nome = aluno.Nome,
                Endereco = aluno.Endereco,
                Email = aluno.Email
            };
        }
    }
}
