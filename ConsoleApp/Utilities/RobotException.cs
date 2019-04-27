using System;

namespace ConsoleApp.Utilities
{
    public class RobotException : Exception
    {
        public RobotException(string message) : base(message)
        {
        }
    }
}
