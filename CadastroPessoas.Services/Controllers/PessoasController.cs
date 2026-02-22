using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pessoas")]
public class PessoasController : ControllerBase
{
    private readonly IMediator _mediator;

    public PessoasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("fisica")]
    public async Task<IActionResult> CriarFisica(CreatePessoaFisicaCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
    Guid id,
    [FromBody] UpdatePessoaFisicaCommand command)
    {
        var updatedCommand = command with { Id = id };

        var result = await _mediator.Send(updatedCommand);

        if (!result)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var result = await _mediator.Send(new GetPessoasQuery());
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var result = await _mediator.Send(new DeletePessoaCommand(id));
        return Ok(result);
    }
}