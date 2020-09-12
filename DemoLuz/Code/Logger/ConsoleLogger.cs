using DemoLuz.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoLuz.Code.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogError(string error)
        {
            Console.WriteLine(error);
        }
    }
}