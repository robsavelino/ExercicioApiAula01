using Microsoft.AspNetCore.Mvc;
using Aula01Api.Core.Interfaces;
using Aula01Api.Core.Model;
using Aula01Api.Controllers.Filters;

namespace Aula01Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientsController : ControllerBase
    {
        public IClientService _clientService;
        public ClientsController (IClientService clientServices)
        {
            _clientService = clientServices;
        }

        #region GET'S
        [HttpGet("cadastros/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Client> GetClients()
        {
            var clients = _clientService.GetClients();
            if(clients == null)
                return NotFound();

            return Ok(clients);
            
        }
        [HttpGet("cadastros/{id}/consultaId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(CheckingIdExistsActionFilter))]

        public ActionResult<Client> GetClient(long id)
        {
            return Ok(_clientService.GetClient(id));
        }
        [HttpGet("cadastros/{cpf}/consultaCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(CpfExistsActionFilter))]
        public ActionResult<Client> GetClient(string cpf)
        {
            return Ok(_clientService.GetClient(cpf));
        }
        #endregion

        #region POST
        [HttpPost("cadastros/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(CpfExistsActionFilter))]
        public ActionResult<Client> InsertClient(Client client)
        {
            if (!_clientService.InsertClient(client))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(InsertClient), client);
        }
        #endregion

        #region PUT
        [HttpPut("cadastros/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ServiceFilter(typeof(CheckingIdExistsActionFilter))]
        public IActionResult UpdateClient(Client updatedClient, long id)
        {
            if (!_clientService.UpdateClient(updatedClient, id))
                return BadRequest();

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("cadastros/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(CheckingIdExistsActionFilter))]
        public IActionResult DeleteCadastro(long id)
        {
            if (!_clientService.DeleteClient(id))
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            return Ok();
        }
        #endregion
    }
}