using ConsoleApp.Common.Interfaces;
using System;

namespace ConsoleApp.Common.Concrete
{
    public class ConsoleWriter : ILogWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
