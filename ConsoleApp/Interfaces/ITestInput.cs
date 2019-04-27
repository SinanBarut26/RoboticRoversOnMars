using System.Collections.Generic;

namespace ConsoleApp.Interfaces
{
    public interface ITestInput
    {
        List<string> Read(string connectionString);
    }
}
