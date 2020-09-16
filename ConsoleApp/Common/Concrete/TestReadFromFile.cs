using ConsoleApp.Common.Interfaces;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Extensions;
using ConsoleApp.Utilities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp.Common.Concrete
{
    /// <summary>
    /// Eğer Configure fonksiyonunu çalıştırmazsanız varsayılan olarak aşağıdaki değerler atanacaktır.
    /// folderPath = "Test"
    /// inputPrefix = "input"
    /// outputPrefix = "output";
    /// </summary>
    public class TestReadFromFile : ITestRead
    {
        private readonly IConfiguration _config;
        private readonly string folderPath = "Test";
        private readonly string inputPrefix = "input";
        private readonly string outputPrefix = "output";

        public TestReadFromFile(IConfiguration config)
        {
            _config = config;
            folderPath = _config["TestRead:FromFile:FolderPath"] ?? folderPath;
            inputPrefix = _config["TestRead:FromFile:InputPrefix"] ?? inputPrefix;
            outputPrefix = _config["TestRead:FromFile:OutputPrefix"] ?? outputPrefix;
        }

        public IEnumerable<string> GetInputsName()
        {
            return Directory.EnumerateFiles(Path.Combine(System.AppContext.BaseDirectory, folderPath),
                $"{inputPrefix}*.txt",
                SearchOption.AllDirectories);
        }

        public IList<string> ReadInput(string inputName)
        {
            var inputs = new List<string>();
            using (var sR = new StreamReader(inputName))
            {
                while (!sR.EndOfStream)
                    inputs.Add(sR.ReadLine());

                return inputs;
            }
        }

        public IList<string> ReadOutput(string inputName)
        {
            var outpufFileName = inputName.Replace(inputPrefix, outputPrefix);
            if (!File.Exists(outpufFileName))
                throw new RobotException(ExceptionEnum.OutputFileNotFound.GetExceptionEnum() + $" => Eksik dosya : {outpufFileName}");
            var outputs = new List<string>();
            using (var sR = new StreamReader(inputName.Replace(inputPrefix, outputPrefix)))
            {
                while (!sR.EndOfStream)
                    outputs.Add(sR.ReadLine());

                return outputs;
            }
        }
    }
}
