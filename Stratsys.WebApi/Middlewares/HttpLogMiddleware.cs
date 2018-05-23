using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Stratsys.WebApi.Loggers;

namespace Stratsys.WebApi.Middlewares
{
    internal class HttpLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger         _logger;

        public HttpLogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var httpLog = new HttpLog(httpContext);
            try
            {
                await _next(httpContext);
                httpLog.Stop();
                _logger.Info(httpLog);
            }
            catch (Exception ex)
            {
                httpLog.Stop();
                //TODO Cratea a corrilationId and show that to the client for esier support tickets

                _logger.Error(httpLog, ex);
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("UNKOWN ERROR");
            }
        }
    }
}