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
        private static readonly ILogWriter writer = new ConsoleWriter();
        private static readonly ITestRead testInput = new TestReadFromFile();

        private static void Main(string[] args)
        {
            try
            {
                var inputFiles = Directory.EnumerateFiles(folderPath, $"{inputPrefix}*.txt", SearchOption.AllDirectories);

                foreach (var inputFile in inputFiles)
                {
                    string outputFile = inputFile.Replace(inputPrefix, outputPrefix);

                    if (!File.Exists(outputFile))
                        throw new RobotException(ExceptionEnum.OutputFileNotFound.GetExceptionEnum());

                    var input = testInput.Read(inputFile);
                    var output = testInput.Read(inputFile.Replace(inputPrefix, outputPrefix));

                    SetupMissionAndMove(input, output);
                }
            }
            catch (RobotException re)
            {
                writer.WriteLine(Environment.NewLine
                    + re.Message
                    + Environment.NewLine);
            }
            catch (Exception)
            {
                writer.WriteLine(Environment.NewLine
                    + ExceptionEnum.ThrowException.GetExceptionEnum()
                    + Environment.NewLine);
            }
            Console.ReadLine();
        }

        private static void SetupMissionAndMove(IList<string> input, IList<string> output)
        {
            ISetupMission setupMission = new SetupMission();
            setupMission.SetupPlateauAndRobot(input,
                out IPlateauInfo plateauInfo,
                out List<IRobotContact> robotContacts);

            var acceptablePositionsOfRobot = output.Select(x => setupMission.SetupRobot(x)).ToList();
            if (robotContacts.Count != acceptablePositionsOfRobot.Count)
                throw new RobotException(ExceptionEnum.InputAndOutputNotEqual.GetExceptionEnum());

            var i = 0;
            foreach (var robotContact in robotContacts)
            {
                RobotMove(robotContact, plateauInfo);

                IsMissionSuccess(acceptablePositionsOfRobot[i++], robotContact.robotInfo);
            }
        }


        private static void RobotMove(IRobotContact robotContact, IPlateauInfo plateauInfo)
        {
            IRobotBehaviour robotBehaviour = new RobotBehaviour(robotContact.robotInfo, plateauInfo);

            writer.WriteLine("Marsa iniş yaptım. 'Hello World!'");

            WriteRobotCurrentPosition(robotContact.robotInfo, "Start");

            foreach (var directive in robotContact.route)
                robotBehaviour.NextMove(directive);

            WriteRobotCurrentPosition(robotContact.robotInfo, "End");

        }

        private static void IsMissionSuccess(IRobotInfo current, IRobotInfo expected)
        {
            if (current.Equals(expected))
                writer.WriteLine("Görev başarılı");
            else
                writer.WriteLine("Beklenen konuma ulaşamadım");

            writer.WriteLine("-----------------------------------------------------------");
        }

        private static void WriteRobotCurrentPosition(IRobotInfo currentRobot, string startOrEnd)
        {
            writer.WriteLine($"{startOrEnd}\t =>\t" +
                $"x:{currentRobot.robot_x}  " +
                $"y:{currentRobot.robot_y}  " +
                $"d:{currentRobot.direction}");
        }
    }
}