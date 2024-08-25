using Application.DTOs;
using Application.Queries.Aluno;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Aluno
{
    public class ObterTodosAlunosQueryHandler : IRequestHandler<ObterTodosAlunosQuery, IEnumerable<AlunoDTO>>
    {
        private readonly IAlunoRepository _alunoRepository;

        public ObterTodosAlunosQueryHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<AlunoDTO>> Handle(ObterTodosAlunosQuery query, CancellationToken cancellationToken)
        {
            var alunos = await _alunoRepository.GetAllAsync();
            return alunos.Select(a => new AlunoDTO
            {
                Nome = a.Nome,
                Endereco = a.Endereco,
                Email = a.Email
            }).ToList();
        }
    }
}
