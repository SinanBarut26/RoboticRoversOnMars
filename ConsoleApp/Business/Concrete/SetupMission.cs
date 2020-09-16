using ConsoleApp.Business.Interfaces;
using ConsoleApp.Entities;
using ConsoleApp.Entities.Enums;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Extensions;
using ConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp.Business.Concrete
{
    /// <summary>
    /// Robotun Mars üzerindeki görevine ilişkin bilgilerin yüklendiği kısım
    /// Örn: Yüzey bilgisi, Robotun konumu ve gideceği rota bilgisi
    /// </summary>
    public class SetupMission : ISetupMission
    {
        public void SetupPlateauAndRobot(IList<string> input, out IPlateauInfo plateauInfo, out List<IRobotContact> robotContacts)
        {
            robotContacts = new List<IRobotContact>();
            plateauInfo = SetupPlateau(input.First().Trim());
            //Arazi değerini aldıktan sonra listeden siliyoruz
            input.RemoveAt(0);

            var inputCount = input.Count;
            for (int i = 0; i < inputCount; i++)
            {
                var robotInfo = SetupRobot(input[i].Trim());
                string routeInfo = string.Empty;
                //Robot için rota verilmediyse rota boş string olur
                routeInfo = i < inputCount - 1 ? SetupRobotRoute(input[++i].Trim().ToUpper()) : "";

                robotContacts.Add(new RobotContact
                {
                    robotInfo = robotInfo,
                    route = routeInfo
                });
            }
        }


        public IPlateauInfo SetupPlateau(string plateau)
        {
            var corners = plateau.Split(" ");
            var plateauInfo = new PlateauInfo();

            if (!int.TryParse(corners[0], out int max_x) || !int.TryParse(corners[1], out int max_y))
                throw new RobotException(ExceptionEnum.PlateauHasNotAcceptableCoordinate.GetExceptionEnum());

            if (max_x > 0 && max_y > 0)
                return new PlateauInfo
                {
                    max_x = Convert.ToInt32(max_x),
                    max_y = Convert.ToInt32(max_y)
                };

            throw new RobotException(ExceptionEnum.PlateauHasNotAcceptableCoordinate.GetExceptionEnum());
        }

        public IRobotInfo SetupRobot(string robot)
        {
            var infos = robot.Split(" ");
            if (!int.TryParse(infos[0], out int x) || !int.TryParse(infos[1], out int y))
                throw new RobotException(ExceptionEnum.PlateauHasNotAcceptableCoordinate.GetExceptionEnum());

            if (!infos[2].isHaveInDirectionEnum())
                throw new RobotException(ExceptionEnum.WrongDirection.GetExceptionEnum());

            return new RobotInfo
            {
                robot_x = x,
                robot_y = y,
                direction = infos[2].GetDirectionEnum()
            };
        }

        private string SetupRobotRoute(string route)
        {
            var routeRegex = new Regex("[RLM]");
            if (!routeRegex.IsMatch(route))
                throw new RobotException(ExceptionEnum.WrongDirection.GetExceptionEnum());

            return route;
        }
    }
}
