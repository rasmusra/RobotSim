using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests
{
    public class RobotSimulatorTests
    {
        [Fact]
        public void WhenCreated_GivenASurface_ThenCanProcessUserCommands()
        {
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            var robotSimulator = new RobotSimulator(surface);

            robotSimulator.Process("PLACE 0,0,NORTH");
            robotSimulator.Process("MOVE");
            robotSimulator.Process("REPORT");
        }
    }
}
