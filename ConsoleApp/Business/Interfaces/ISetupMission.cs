using ConsoleApp.Entities.Interface;
using System.Collections.Generic;

namespace ConsoleApp.Business.Interfaces
{
    public interface ISetupMission
    {
        void SetupPlateauAndRobot(List<string> input,
            out IPlateauInfo plateauInfo, out List<IRobotContact> robotContacts);
        IPlateauInfo SetupPlateau(string plateau);
        IRobotInfo SetupRobot(string robot);
    }
}
