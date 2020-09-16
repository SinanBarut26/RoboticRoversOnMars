using System.Collections.Generic;

namespace ConsoleApp.Business.Interfaces
{
    public interface IPerformMission
    {
        IEnumerable<string> SetupMissionAndMove(IList<string> input);//, IList<string> output);

    }
}
