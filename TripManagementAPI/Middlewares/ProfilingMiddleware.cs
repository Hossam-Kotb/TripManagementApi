using System.Diagnostics;

namespace WebApplication2.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _loger;

        public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> loger)
        {
            _next = next;
            _loger = loger;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch =new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _loger.LogInformation($"Request : {context.Request.Path} | Took : {stopwatch.ElapsedMilliseconds}");


        }
    }
}
