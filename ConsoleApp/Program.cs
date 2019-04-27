using ConsoleApp.Business.Concrete;
using ConsoleApp.Business.Interfaces;
using ConsoleApp.Common.Concrete;
using ConsoleApp.Common.Interfaces;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Extensions;
using ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly string folderPath = "../../../../Test/";
        private static readonly string inputPrefix = "input";
        private static readonly string outputPrefix = "output";
        private static void Main(string[] args)
        {
            ILogWriter writer = new ConsoleWriter();
            try
            {
                ITestRead testInput = new TestReadFromFile();

                var inputFiles = Directory.EnumerateFiles(folderPath, $"{inputPrefix}*.txt", SearchOption.AllDirectories);

                foreach (var inputFile in inputFiles)
                {
                    string outputFile = inputFile.Replace(inputPrefix, outputPrefix);

                    if (!File.Exists(outputFile))
                        throw new RobotException(ExceptionEnum.OutputFileNotFound.GetExceptionEnum());

                    var input = testInput.Read(inputFile);
                    var output = testInput.Read(inputFile.Replace(inputPrefix, outputPrefix));

                    ISetupMission setupMission = new SetupMission();
                    setupMission.SetupPlateauAndRobot(input,
                        out IPlateauInfo plateauInfo,
                        out List<IRobotContact> robotContacts);

                    var acceptablePositionsOfRobot = output.Select(x => setupMission.SetupRobot(x)).ToList();
                    if (robotContacts.Count != acceptablePositionsOfRobot.Count)
                        throw new RobotException(ExceptionEnum.InputAndOutputNotEqual.GetExceptionEnum());

                    foreach (var robotContact in robotContacts)
                    {
                        IRobotBehaviour robotBehaviour = new RobotBehaviour(robotContact.robotInfo, plateauInfo);
                        writer.WriteLine("Marsa iniş yaptım. 'Hello World!'");
                        writer.Write($"x:{robotContact.robotInfo.robot_x}  " +
                            $"y:{robotContact.robotInfo.robot_y}  " +
                            $"d:{robotContact.robotInfo.direction}");

                        foreach (var directive in robotContact.route)
                            robotBehaviour.NextMove(directive);

                        writer.WriteLine($"   =>   " +
                            $"x:{robotContact.robotInfo.robot_x}  " +
                            $"y:{robotContact.robotInfo.robot_y}  " +
                            $"d:{robotContact.robotInfo.direction}");

                        if (acceptablePositionsOfRobot.First().Equals(robotContact.robotInfo))
                        {
                            acceptablePositionsOfRobot.RemoveAt(0);
                            writer.WriteLine("Görev başarılı");
                        }
                        else
                        {
                            writer.WriteLine("Beklenen konuma ulaşamadım");
                        }

                        writer.WriteLine("-----------------------------------------------------------");
                    }
                }
            }
            catch (RobotException re)
            {
                writer.WriteLine(default);
                writer.WriteLine(re.Message);
                writer.WriteLine(default);
            }
            catch (Exception)
            {
                writer.WriteLine(default);
                writer.WriteLine(ExceptionEnum.ThrowException.GetExceptionEnum());
                writer.WriteLine(default);
            }
            Console.ReadLine();
        }
    }




}
