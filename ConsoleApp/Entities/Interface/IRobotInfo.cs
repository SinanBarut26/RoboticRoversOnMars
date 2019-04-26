using ConsoleApp.Entities.Enums;

namespace ConsoleApp.Entities.Interface
{
    public interface IRobotInfo
    {
        int robot_x { get; set; }
        int robot_y { get; set; }
        Direction direction { get; set; }
    }
}
