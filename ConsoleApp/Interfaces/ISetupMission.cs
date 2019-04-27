using ConsoleApp.Entities.Interface;
using System.Collections.Generic;

namespace ConsoleApp.Interfaces
{
    public interface ISetupMission
    {
        void SetupPlateauAndRobot(List<string> input,
            out IPlateauInfo plateauInfo, out List<IRobotContact> robotContacts);
    }
}
