using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Business.Concrete;
using ConsoleApp.Business.Interfaces;
using ConsoleApp.Common.Concrete;
using Xunit;

namespace Tests
{
    public class RobotMoveTest
    {
        private readonly IPerformMission _performMission;
        public RobotMoveTest()
        {
            _performMission = new PerformMission(new ConsoleWriter());
        }
        [Fact]
        public void Test1()
        {
            var input = new List<string>();
            input.Add("5 5");
            input.Add("1 2 N");
            input.Add("LMLMLMLMM");

            var output = new List<string>();
            output.Add("1 3 N");
            var result = _performMission.SetupMissionAndMove(input);//, output);
            Assert.Equal(result.ToList(), output);

        }

        [Fact]
        public void Test2()
        {
            var input = new List<string>();
            input.Add("5 5");
            input.Add("1 2 N");
            input.Add("LMLMLMLMM");

            var output = new List<string>();
            output.Add("2 3 N");
            var result = _performMission.SetupMissionAndMove(input);//, output);

            Assert.NotEqual(result.ToList(), output);
        }


        [Fact]
        public void Test3()
        {
            var input = new List<string>();
            input.Add("8 8");
            input.Add("1 2 N");
            input.Add("RMMMMMRRMMRRMM");
            input.Add("2 2 N");
            input.Add("RMMMMMRRMMRRMM");

            var output = new List<string>();
            output.Add("6 2 E");
            output.Add("7 2 E");
            var result = _performMission.SetupMissionAndMove(input);//, output);

            Assert.Equal(result.ToList(), output);
        }
    }
}
