using ConsoleApp.Interfaces;
using System;

namespace ConsoleApp.Concrete
{
    public class ConsoleWriter : ILogWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
