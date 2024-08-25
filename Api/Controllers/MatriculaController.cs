using Application.Commands.Matricula;
using Application.DTOs;
using Application.Queries.Matricula;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatriculaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            var query = new ObterTodasMatriculasQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaDTO>> Get(Guid id)
        {
            var query = new ObterMatriculaPorIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CadastrarMatriculaCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarMatriculaCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletarMatriculaCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPost("matricular")]
        public async Task<IActionResult> MatricularAluno(Guid alunoId, Guid cursoId)
        {
            var command = new MatricularAlunoCommand(alunoId, cursoId);
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest("Não foi possível matricular o aluno.");

            return Ok("Aluno matriculado com sucesso.");
        }

        [HttpPost("concluir")]
        public async Task<IActionResult> ConcluirMatricula(Guid matriculaId)
        {
            var command = new ConcluirMatriculaCommand(matriculaId);
            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest("Não foi possível concluir a matrícula.");

            return Ok("Matrícula concluída com sucesso.");
        }
    }
}
