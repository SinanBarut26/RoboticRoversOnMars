using ConsoleApp.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.Concrete
{
    public class TestInputFromFile : ITestInput
    {
        public List<string> Read(string connectionString)
        {
            var sampleInput = new List<string>();
            using (var sR = new StreamReader(connectionString))
            {
                while (!sR.EndOfStream)
                {
                    sampleInput.Add(sR.ReadLine());
                }
                return sampleInput;
            }
        }
    }
}
