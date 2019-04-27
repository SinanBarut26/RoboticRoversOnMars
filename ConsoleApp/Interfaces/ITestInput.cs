using System.Collections.Generic;

namespace ConsoleApp.Interfaces
{
    public interface ITestRead
    {
        List<string> Read(string connectionString);
    }
}
