using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Interfaces
{
    public interface IRobotBehaviour
    {
        IRobotInfo Move();
        IRobotInfo ChangeDirection(char turn);
    }
}
