using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Interfaces
{
    public interface IRobotBehaviour
    {
        IRobotContact NextMove();
        IRobotInfo Move();
        IRobotInfo ChangeDirection(char turn);
    }
}
