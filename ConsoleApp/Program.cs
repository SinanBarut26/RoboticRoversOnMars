using ConsoleApp.Business.Concrete;
using ConsoleApp.Business.Interfaces;
using ConsoleApp.Common.Concrete;
using ConsoleApp.Common.Interfaces;
using ConsoleApp.Entities;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Extensions;
using ConsoleApp.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static ILogWriter writer;
        private static ITestRead testInput;
        private static IPerformMission performMission;

        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            RegisterServices(configuration);


            Start();


            // Console.ReadLine();
        }

        private static void RegisterServices(IConfiguration configuration)

        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<ILogWriter, ConsoleWriter>()
                .AddSingleton<ITestRead, TestReadFromFile>()
                .AddSingleton<IPerformMission, PerformMission>()
                .BuildServiceProvider();

            writer = serviceProvider.GetService<ILogWriter>();
            testInput = serviceProvider.GetService<ITestRead>();
            performMission = serviceProvider.GetService<IPerformMission>();
        }

        public static void Start()
        {
            try
            {
                foreach (var inputFile in testInput.GetInputsName())
                {
                    var input = testInput.ReadInput(inputFile);
                    var output = testInput.ReadOutput(inputFile);

                    var result = performMission.SetupMissionAndMove(input);//, output);
                    IsMissionSuccess(result.ToList(), output.ToList());
                }
            }
            catch (RobotException re)
            {
                writer.WriteLine(Environment.NewLine
                    + re.Message
                    + Environment.NewLine);
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
                writer.WriteLine(Environment.NewLine
                    + ExceptionEnum.ThrowException.GetExceptionEnum()
                    + Environment.NewLine);
            }
        }


        private static void IsMissionSuccess(List<string> result, List<string> output)
        {
            if (result.Count != output.Count)
                throw new RobotException(ExceptionEnum.InputAndOutputNotEqual.GetExceptionEnum());

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == output[i])
                {
                    writer.WriteLine($"Result \t\t{result[i]}");
                    writer.WriteLine($"Expected \t{output[i]}");
                    writer.WriteLine("Görev başarılı");
                }
                else
                {
                    writer.WriteLine($"Result \t\t{result[i]}");
                    writer.WriteLine($"Expected \t{output[i]}");
                    writer.WriteLine("Beklenen konuma ulaşamadım");
                }
                writer.WriteLine("-----------------------------------------------------------");
            }
        }

    }
}