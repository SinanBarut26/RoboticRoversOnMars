using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Entities.Concrete
{
    public class RobotInfo : IRobotInfo
    {
        public int robot_x { get; set; }
        public int robot_y { get; set; }
        public Direction direction { get; set; }

    }
}
