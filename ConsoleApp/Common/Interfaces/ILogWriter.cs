namespace ConsoleApp.Common.Interfaces
{
    public interface ILogWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
