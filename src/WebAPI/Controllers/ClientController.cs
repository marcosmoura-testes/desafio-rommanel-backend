using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CreateClientCommand createClientCommand)
        {
            var clientResponse = await _mediator.Send(createClientCommand);

            return CreatedAtAction(nameof(GetClientById), new { id = clientResponse.Id }, clientResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var clientQuery = new GetClientByIdQuery(id);
            var client = await _mediator.Send(clientQuery);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] UpdateClientCommand updateClientCommand)
        {
            if (id != updateClientCommand.Id)
            {
                return BadRequest("Id do cliente não corresponde ao fornecido.");
            }

            var clientResponse = await _mediator.Send(updateClientCommand);
            if (clientResponse == null)
            {
                return NotFound();
            }

            return Ok(clientResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var deleteClientCommand = new DeleteClientCommand(id);
            var clientResponse = await _mediator.Send(deleteClientCommand);

            if (clientResponse == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
