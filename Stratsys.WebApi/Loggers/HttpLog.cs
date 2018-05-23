using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using Startsys.Core.Loggers;

namespace Stratsys.WebApi.Loggers
{
    public class HttpLog
    {
        private readonly HttpContext _httpContext;

        public  string    Path                { get; set; }
        public  IPAddress IpAddress           { get; set; }
        public  string    Referer             { get; set; }
        public  string    UserAgent           { get; set; }
        private Stopwatch Stopwatch           { get; set; }
        public  int?      StatusCode          { get; set; }
        public  long      ElipsedMilliseconds => Stopwatch.ElapsedMilliseconds;


        public LogLevel Level => (!StatusCode.HasValue || StatusCode.Value > 499) ? LogLevel.Error : LogLevel.Info;

        public HttpLog(HttpContext httpContext)
        {
            _httpContext = httpContext;
            Stopwatch = Stopwatch.StartNew();
            Path = $"{httpContext.Request.Method}: {httpContext.Request.Path}";
            IpAddress = httpContext.Connection.RemoteIpAddress;
            Referer = httpContext.Request.Headers["Referer"];
            UserAgent = httpContext.Request.Headers["User-Agent"];
        }

        public void Stop()
        {
            Stopwatch.Stop();
            StatusCode = _httpContext.Response?.StatusCode;
        }

        public override string ToString()
        {
            return $"Path:{Path}, Duration:{ElipsedMilliseconds}, StausCode:{StatusCode}, Ip:{IpAddress}, Referer:{Referer}, UserAgent:{UserAgent} ";
        }
    }
}