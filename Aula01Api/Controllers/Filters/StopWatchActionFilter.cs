using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Aula01Api.Controllers.Filters
{
    public class StopWatchActionFilter : IActionFilter
    {
        public Stopwatch sw = new();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            Console.WriteLine($"Elapsed time: {ts.TotalSeconds}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            sw.Start();
        }
    }
}
