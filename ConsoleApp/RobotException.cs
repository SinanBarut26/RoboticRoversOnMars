using System;

namespace ConsoleApp
{
    public class RobotException : Exception
    {
        public RobotException(string message) : base(message)
        {
        }
    }
}
