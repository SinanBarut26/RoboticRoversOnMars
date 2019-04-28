using System.Collections.Generic;

namespace ConsoleApp.Common.Interfaces
{
    public interface ITestRead
    {
        IEnumerable<string> GetInputsName();
        IList<string> ReadInput(string inputName);
        IList<string> ReadOutput(string inputName);
    }
}
