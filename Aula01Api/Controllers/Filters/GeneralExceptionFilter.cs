using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace Aula01Api.Controllers.Filters
{
    public class GeneralExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Unnexpected error",
                Detail = "An unnexpected error has occourred",
                Type = context.Exception.GetType().Name
            };
            Console.WriteLine($"Type: {context.Exception.GetType().Name}, Message: {context.Exception.Message}, Stack Trace {context.Exception.StackTrace}");

            switch (context.Exception)
            {
                case SqlException:
                    problem.Status = 500;
                    problem.Title = "Internal Server Error";
                    problem.Detail = "Unnexpected error when trying to reach the Data base";
                    problem.Type = context.Exception.GetType().Name;
                    context.Result = new ObjectResult(problem);
                    break;

                case NullReferenceException:
                    problem.Status = 417;
                    problem.Title = "Bad Request";
                    problem.Detail = "Unexpected error occourred";
                    problem.Type = context.Exception.GetType().Name;
                    context.Result = new ObjectResult(problem);
                    break;

                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problem);
                    break;

            }
        }
    }
}
