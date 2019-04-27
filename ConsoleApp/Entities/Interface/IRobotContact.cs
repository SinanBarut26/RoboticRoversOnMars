namespace ConsoleApp.Entities.Interface
{
    public interface IRobotContact
    {
        IRobotInfo robotInfo { get; set; }
        string route { get; set; }
    }
}