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
        [Theory]
        [InlineData("PLACE 0,0,NORTH", "0,1,NORTH")]
        [InlineData("PLACE 0,0,EAST", "1,0,EAST")]
        [InlineData("PLACE 0,1,SOUTH", "0,0,SOUTH")]
        [InlineData("PLACE 1,0,WEST", "0,0,WEST")]
        public void WhenMovingRobot_GivenRobotExists_ThenMovedRobotIsReported(
            string placementCommand, string expectedReport)
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process(placementCommand);
            robotSimulator.Process("MOVE");
            robotSimulator.Process("REPORT");

            Assert.Single(reports);
            Assert.Equal(expectedReport, reports[0]);
        }
        [Theory]
        [InlineData("PLACE 0,4,NORTH", "0,4,NORTH")]
        [InlineData("PLACE 4,0,EAST", "4,0,EAST")]
        [InlineData("PLACE 0,0,SOUTH", "0,0,SOUTH")]
        [InlineData("PLACE 0,0,WEST", "0,0,WEST")]
        public void WhenMovingRobot_GivenRobotIsAtBorder_ThenUnmovedRobotIsReported(
            string placementCommand, string expectedReport)
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process(placementCommand);
            robotSimulator.Process("MOVE");
            robotSimulator.Process("REPORT");

            Assert.Single(reports);
            Assert.Equal(expectedReport, reports[0]);
        }
    }
}
