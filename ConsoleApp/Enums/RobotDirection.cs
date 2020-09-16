using ConsoleApp.Entities.Enums.Attributes;

namespace ConsoleApp.Entities.Enums
{
    public enum RobotDirection
    {
        [CharValue('N')]
        Nort = 0,
        [CharValue('E')]
        East = 1,
        [CharValue('S')]
        South = 2,
        [CharValue('W')]
        West = 3
    }
}
