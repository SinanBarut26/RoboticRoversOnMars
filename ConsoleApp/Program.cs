using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        readonly static PlateauArea plateauArea = new PlateauArea
        {
            max_x = 5,
            max_y = 5
        };

        //static RobotInfo robotInfo = new RobotInfo
        //{
        //    robot_x = 1,
        //    robot_y = 2,
        //    direction = Direction.Nort
        //};

        //private static string path = "LMLMLMLMM";





        static RobotInfo robotInfo = new RobotInfo
        {
            robot_x = 3,
            robot_y = 3,
            direction = Direction.East
        };
        private static string path = "MMRMMRMRRM";


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var regex = new Regex("[RLM]");



            foreach (var item in path)
            {
                if (!regex.IsMatch(item.ToString()))
                {
                    Console.WriteLine("Lütfen gideceğim yolu kontrol, sanırım bir yanlışlık var :)");
                    break;
                }

                Console.WriteLine($"x:{robotInfo.robot_x}  y:{robotInfo.robot_y}  d:{robotInfo.direction}");
                if (item == 'R' || item == 'L')
                    robotInfo = robotInfo.NextDirection(item);
                else
                    robotInfo = robotInfo.Move();

            }
            Console.WriteLine($"Son olarak durduğum konum");
            Console.WriteLine($"x:{robotInfo.robot_x}  y:{robotInfo.robot_y}  d:{robotInfo.direction}");
            Console.ReadLine();
        }
    }


    public enum Turn
    {
        Right = 1,
        Left = 2
    }

    public enum Direction
    {
        Nort = 0,
        East = 1,
        South = 2,
        West = 3
    }


}
