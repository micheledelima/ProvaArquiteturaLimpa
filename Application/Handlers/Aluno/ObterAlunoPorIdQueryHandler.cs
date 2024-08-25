using Application.DTOs;
using Application.Queries.Aluno;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Aluno
{
    public class ObterAlunoPorIdQueryHandler : IRequestHandler<ObterAlunoPorIdQuery, AlunoDTO>
    {
        private readonly IAlunoRepository _alunoRepository;

        public ObterAlunoPorIdQueryHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoDTO> Handle(ObterAlunoPorIdQuery query, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(query.Id);
            if (aluno == null) return null;

            return new AlunoDTO
            {
                Nome = aluno.Nome,
                Endereco = aluno.Endereco,
                Email = aluno.Email
            };
        }
    }
}
