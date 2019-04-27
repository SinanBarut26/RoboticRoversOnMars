using ConsoleApp.Concrete;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ILogWriter writer = new ConsoleWriter();

            ITestInput testInput = new TestInputFromFile();
            var input = testInput.Read("../../../../Test/input_001.txt");

            ISetupMission setupMission = new SetupMission();
            setupMission.SetupPlateauAndRobot(input, out IPlateauInfo plateauInfo, out List<IRobotContact> robotContacts);

            foreach (var robotContact in robotContacts)
            {
                IRobotBehaviour robotBehaviour = new RobotBehaviour(robotContact.robotInfo, plateauInfo);
                writer.Write("Marsa iniş yaptım. 'Hello World!'");
                writer.Write($"Başlangıç konumum");
                writer.Write($"x:{robotContact.robotInfo.robot_x}  y:{robotContact.robotInfo.robot_y}  d:{robotContact.robotInfo.direction}");

                foreach (var directive in robotContact.route)
                {
                    if (directive == 'R' || directive == 'L')
                        robotBehaviour.ChangeDirection(directive);
                    else
                        robotBehaviour.Move();
                }

                writer.Write($"Son olarak durduğum konum");
                writer.Write($"x:{robotContact.robotInfo.robot_x}  y:{robotContact.robotInfo.robot_y}  d:{robotContact.robotInfo.direction}");
                writer.Write(Environment.NewLine + Environment.NewLine);

            }

            Console.ReadLine();
        }
    }




}
