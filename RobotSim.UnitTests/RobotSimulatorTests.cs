using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests
{
    public class RobotSimulatorTests
    {
        [Theory]
        [InlineData("LEFT")]
        [InlineData("RIGHT")]
        [InlineData("MOVE")]
        public void WhenCommand_GivenNoRobot_ThenNothingIsReported(string command)
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process(command);
            robotSimulator.Process("REPORT");

            Assert.Empty(reports);
        }
        [Fact]
        public void WhenPlacingRobot_GivenInsideSurface_ThenPositionIsReported()
        {
            var expectedReport = "0,0,NORTH";
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("PLACE 0,0,NORTH");
            robotSimulator.Process("REPORT");

            Assert.Single(reports);
            Assert.Equal(expectedReport, reports[0]);
        }
        [Fact]
        public void WhenPlacingRobot_GivenOutsideSurface_ThenNothingIsReported()
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("PLACE 0,5,NORTH");
            robotSimulator.Process("REPORT");

            Assert.Empty(reports);
        }
        [Fact]
        public void WhenMovingRobot_GivenNoRobotYet_ThenNothingIsReported()
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("MOVE");
            robotSimulator.Process("REPORT");

            Assert.Empty(reports);
        }
        [Fact]
        public void WhenMovingRobot_GivenRobotExists_ThenMovedRobotIsReported()
        {
            var expectedReport = "0,4,NORTH";
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("PLACE 0,3,NORTH");
            robotSimulator.Process("MOVE");
            robotSimulator.Process("REPORT");

            Assert.Single(reports);
            Assert.Equal(expectedReport, reports[0]);
        }
    }
}
