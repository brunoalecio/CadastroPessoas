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

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var result = await _mediator.Send(new GetPessoasQuery());
        return Ok(result);
    }
}