using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Aula01Api.Controllers.Filters
{
    public class StopWatchResourceFilter : IResourceFilter
    {
        public Stopwatch sw = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            Console.WriteLine($"Elapsed time: {ts.TotalSeconds}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            sw.Start();
        }
    }
}
