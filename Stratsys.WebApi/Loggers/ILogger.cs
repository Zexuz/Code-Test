using System;

namespace Stratsys.WebApi.Loggers
{
    public interface ILogger
    {
        void Info(HttpLog log);
        void Error(HttpLog log, Exception exception);
    }
}