using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests
{
    public class RobotSimulatorTests
    {
        [Fact]
        public void WhenCreated_GivenASurface_ThenCanProcessUserCommands()
        {
            var reports = new List<string>();
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface, reports.Add);

            robotSimulator.Process("REPORT");

            Assert.Empty(reports);
        }
    }

    public class ReporterSpy : Reporter
    {
        public readonly List<string> Reports = [];

        public override void WriteLine(string message)
        {
            Reports.Add(message);
        }
    }
}
