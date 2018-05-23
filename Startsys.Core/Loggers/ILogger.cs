using System;

namespace Startsys.Core.Loggers
{
    public interface ILogger
    {
        void Info(string str);
        void Error(string str, Exception exception);
    }
}