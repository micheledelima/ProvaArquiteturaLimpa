using Application.Commands.Aluno;
using Application.DTOs;
using Application.Queries.Aluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoDTO alunoDto)
        {
            var command = new CadastrarAlunoCommand(alunoDto.Nome, alunoDto.Endereco, alunoDto.Email);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id }, alunoDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> GetAll()
        {
            var query = new ObterTodosAlunosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDTO>> Get(Guid id)
        {
            var query = new ObterAlunoPorIdQuery(id);
            var aluno = await _mediator.Send(query);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoDTO>> Put(Guid id, [FromBody] AlunoDTO alunoDto)
        {
            var command = new AtualizarAlunoCommand(id, alunoDto.Nome, alunoDto.Endereco, alunoDto.Email);
            var updatedAluno = await _mediator.Send(command);
            if (updatedAluno == null)
                return NotFound();

            return Ok(updatedAluno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletarAlunoCommand(id));
            return NoContent();
        }
    }
}