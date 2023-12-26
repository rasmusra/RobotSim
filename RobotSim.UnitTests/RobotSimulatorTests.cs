using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests
{
    public class RobotSimulatorTests
    {
        [Fact]
        public void WhenReport_GivenNoRobot_ThenCanProcessUserCommands()
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("REPORT");

            Assert.Single(reports);
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
    }
}
