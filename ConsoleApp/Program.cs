using ConsoleApp.Concrete;
using ConsoleApp.Entities.Concrete;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        readonly static IPlateauInfo plateauInfo = new PlateauInfo
        {
            min_x = 0,
            min_y = 0,
            max_x = 5,
            max_y = 5,
        };

        static IRobotInfo robotInfo = new RobotInfo
        {
            robot_x = 1,
            robot_y = 2,
            direction = Direction.Nort
        };

        private static string path = "LMLMLMLMM";
        //private static string path = "LMMLMLMLMM";//RobotException





        //static RobotInfo robotInfo = new RobotInfo
        //{
        //    robot_x = 3,
        //    robot_y = 3,
        //    direction = Direction.East
        //};
        //private static string path = "MMRMMRMRRM";


        static void Main(string[] args)
        {
            ILogWriter writer = new ConsoleWriter();
            writer.Write("Marsa iniş yaptım. 'Hello World!'");

            char out_direction = 'N';
            if (!out_direction.isHaveInDirectionEnum())
                throw new RobotException("Malesef önümü göremiyorum. Çünkü tanımladığın yön pusulamda bulunmuyor");

            Direction in_direction = out_direction.GetDirectionEnum();

            var regex = new Regex("[RLM]");

            IRobotBehaviour robotBehaviour = new RobotBehaviour(robotInfo, plateauInfo);

            foreach (var directive in path)
            {
                if (!regex.IsMatch(directive.ToString()))
                    throw new RobotException("Tanımlayamadığım bazı hareketler mevcut. Yeniden gözden geçirebilir misin?");

                writer.Write($"x:{robotInfo.robot_x}  y:{robotInfo.robot_y}  d:{robotInfo.direction}");

                if (directive == 'R' || directive == 'L')
                    robotBehaviour.ChangeDirection(directive);
                else
                    robotBehaviour.Move();

            }

            writer.Write($"Son olarak durduğum konum");
            writer.Write($"x:{robotInfo.robot_x}  y:{robotInfo.robot_y}  d:{robotInfo.direction}");
            Console.ReadLine();
        }
    }




}
