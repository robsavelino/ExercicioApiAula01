using Aula01Api.Core.Interfaces;
using Aula01Api.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01Api.Controllers.Filters
{
    public class CpfExistsActionFilter : ActionFilterAttribute
    {
        public IClientService _clientService;
        public CpfExistsActionFilter(IClientService clientService)
        {
            _clientService = clientService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var client = context.ActionArguments["client"] as Client;


            if (_clientService.GetClient(client.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
