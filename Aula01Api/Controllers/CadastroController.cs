using Microsoft.AspNetCore.Mvc;
using Aula01Api.Core.Interfaces;
using Aula01Api.Core.Model;

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


        [HttpGet("cadastros/{id}/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Client> GetClient(long id)
        {
            var client = _clientService.GetClient(id);
            if (client == null)
                return NotFound();

            return Ok(_clientService.GetClient(id));
        }
        #endregion

        #region POST
        [HttpPost("cadastros/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> InsertClient(Client newClient)
        {
            if (!_clientService.InsertClient(newClient))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(InsertClient), newClient);
        }
        #endregion

        #region PUT
        [HttpPut("cadastros/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        public IActionResult DeleteCadastro(long id)
        {
            if (!_clientService.DeleteClient(id))
                return NotFound();
            return Ok();
        }
        #endregion
    }
}