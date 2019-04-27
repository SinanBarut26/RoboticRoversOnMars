using ConsoleApp.Business.Concrete;
using ConsoleApp.Business.Interfaces;
using ConsoleApp.Common.Concrete;
using ConsoleApp.Common.Interfaces;
using ConsoleApp.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ILogWriter writer = new ConsoleWriter();

            ITestRead testInput = new TestReadFromFile();
            var input = testInput.Read("../../../../Test/input_001.txt");
            var output = testInput.Read("../../../../Test/output_001.txt");

            ISetupMission setupMission = new SetupMission();
            setupMission.SetupPlateauAndRobot(input, out IPlateauInfo plateauInfo, out List<IRobotContact> robotContacts);
            var acceptablePositionsOfRobot = output.Select(x => setupMission.SetupRobot(x)).ToList();


            foreach (var robotContact in robotContacts)
            {
                IRobotBehaviour robotBehaviour = new RobotBehaviour(robotContact.robotInfo, plateauInfo);
                writer.WriteLine("Marsa iniş yaptım. 'Hello World!'");
                writer.Write($"x:{robotContact.robotInfo.robot_x}  y:{robotContact.robotInfo.robot_y}  d:{robotContact.robotInfo.direction}");

                foreach (var directive in robotContact.route)
                {
                    if (directive == 'R' || directive == 'L')
                        robotBehaviour.ChangeDirection(directive);
                    else
                        robotBehaviour.Move();
                }
                writer.Write("   =>   ");
                writer.WriteLine($"x:{robotContact.robotInfo.robot_x}  y:{robotContact.robotInfo.robot_y}  d:{robotContact.robotInfo.direction}");
                if (acceptablePositionsOfRobot.First().Equals(robotContact.robotInfo))
                {
                    acceptablePositionsOfRobot.RemoveAt(0);
                    writer.WriteLine("Görev başarılı");
                }
                else
                {
                    writer.WriteLine("Beklenen konuma ulaşamadım");
                }

                writer.WriteLine("-----------------------------------------------------------" + Environment.NewLine);

            }

            Console.ReadLine();
        }
    }




}
