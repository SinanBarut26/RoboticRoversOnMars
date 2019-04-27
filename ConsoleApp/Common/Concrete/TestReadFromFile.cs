using ConsoleApp.Common.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.Common.Concrete
{
    public class TestReadFromFile : ITestRead
    {
        public List<string> Read(string connectionString)
        {
            var inputs = new List<string>();
            using (var sR = new StreamReader(connectionString))
            {
                while (!sR.EndOfStream)
                {
                    inputs.Add(sR.ReadLine());
                }
                return inputs;
            }
        }
    }
}
