using System.Collections.Generic;

namespace ConsoleApp.Common.Interfaces
{
    public interface ITestRead
    {
        List<string> Read(string connectionString);
    }
}
