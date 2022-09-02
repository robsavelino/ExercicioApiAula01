using Microsoft.AspNetCore.Mvc;
using Aula01Api.Repositories;
namespace Aula01Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientsController : ControllerBase
    {
        public List<Clients> ClientsList { get; set; }

        public ClientsRepositories _repositoriesClients;
        public ClientsController (IConfiguration configuration)
        {
            ClientsList = new List<Clients>();
            _repositoriesClients = new ClientsRepositories(configuration);
        }

        [HttpGet("cadastros/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Clients> GetClients()
        {
            var clients = _repositoriesClients.GetClients();
            if(clients == null)
                return NotFound();

            return Ok(clients);
            
        }


        [HttpGet("cadastros/{id}/consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Clients> GetClient(long id)
        {
            var client = _repositoriesClients.GetClient(id);
            if (client == null)
                return NotFound();

            return Ok(_repositoriesClients.GetClient(id));
        }


        [HttpPost("cadastros/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clients> InsertClient(Clients newClient)
        {
            if (!_repositoriesClients.InsertClient(newClient))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(InsertClient), newClient);
        }

        [HttpPut("cadastros/{id}/atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateClient(Clients updatedClient, long id)
        {
            if (!_repositoriesClients.UpdateClient(updatedClient, id))
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("cadastros/{id}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCadastro(long id)
        {
            if (!_repositoriesClients.DeleteClient(id))
                return NotFound();
            return Ok();
        }
    }
}