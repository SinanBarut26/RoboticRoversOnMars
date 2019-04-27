using ConsoleApp.Entities.Interface;

namespace ConsoleApp.Business.Interfaces
{
    /// <summary>
    /// Robotun sahip olduğu davranışların uygulanması için oluşturulan interface
    /// </summary>
    public interface IRobotBehaviour
    {
        IRobotInfo NextMove(char direction);
    }
}
