using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Entities
{
    public class RobotInfo : IRobotInfo
    {
        public int robot_x { get; set; }
        public int robot_y { get; set; }
        public RobotDirection direction { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RobotInfo ınfo &&
                   robot_x == ınfo.robot_x &&
                   robot_y == ınfo.robot_y &&
                   direction == ınfo.direction;
        }
    }
}
