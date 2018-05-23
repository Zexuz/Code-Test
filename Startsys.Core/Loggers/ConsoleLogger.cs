using System;

namespace Startsys.Core.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string str)
        {
            Console.WriteLine(str);
        }

        public void Error(string str, Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.ToString());
        }
    }
}