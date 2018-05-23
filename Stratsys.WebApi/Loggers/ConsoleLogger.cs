using System;

namespace Stratsys.WebApi.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Info(HttpLog log)
        {
            Console.WriteLine(FormatString(log));
        }

        public void Error(HttpLog log, Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(FormatString(log));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.ToString());
        }

        private string FormatString(HttpLog info)
        {
            return
                $"Path:{info.Path}, Duration:{info.ElipsedMilliseconds}, StausCode:{info.StatusCode}, Ip:{info.IpAddress}, Referer:{info.Referer}, UserAgent:{info.UserAgent} ";
        }
    }
}