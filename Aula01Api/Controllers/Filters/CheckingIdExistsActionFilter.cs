using Aula01Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01Api.Controllers.Filters
{
    public class CheckingIdExistsActionFilter :ActionFilterAttribute
    {
        public IClientService _clientService;

        public CheckingIdExistsActionFilter(IClientService clientService)
        {
            _clientService = clientService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long id = (long)context.ActionArguments["id"];

            if (_clientService.GetClient(id) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }
        }

    }
}
