using ConsoleApp.Business.Interfaces;
using ConsoleApp.Common.Interfaces;
using ConsoleApp.Entities.Enums.Attributes;
using ConsoleApp.Entities.Interface;
using ConsoleApp.Extensions;
using System.Collections.Generic;

namespace ConsoleApp.Business.Concrete
{
    /// <summary>
    /// Robotun Mars üzerindeki görevin gerçekleştirmesini sağlayan kısım
    /// </summary>
    public class PerformMission : IPerformMission
    {
        private readonly ILogWriter writer;
        public PerformMission(ILogWriter writer)
        {
            this.writer = writer;
        }
        public IEnumerable<string> SetupMissionAndMove(IList<string> input)//, IList<string> output)
        {
            ISetupMission setupMission = new SetupMission();
            setupMission.SetupPlateauAndRobot(input,
                out IPlateauInfo plateauInfo,
                out List<IRobotContact> robotContacts);

            foreach (var robotContact in robotContacts)
            {
                RobotMove(robotContact, plateauInfo);
                yield return $"{robotContact.robotInfo.robot_x} {robotContact.robotInfo.robot_y} {robotContact.robotInfo.direction.GetAttribute<CharValue>().value}";
            }
        }


        private void RobotMove(IRobotContact robotContact, IPlateauInfo plateauInfo)
        {
            IRobotBehaviour robotBehaviour = new RobotBehaviour(robotContact.robotInfo, plateauInfo);

            foreach (var directive in robotContact.route)
                robotBehaviour.NextMove(directive);
        }
    }
}
