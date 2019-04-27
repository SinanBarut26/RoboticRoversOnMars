using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Entities
{
    public class RobotContact : IRobotContact
    {
        public IRobotInfo robotInfo { get; set; }
        public string route { get; set; }
    }
}
