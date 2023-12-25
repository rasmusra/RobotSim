using RobotSim.Domain;
using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Given(ScenarioContext context)
    {
        [Given("the robot is off the table")]
        public void RemoveAnyRobot()
        {
            var surface = new Surface(new Position(0, 0), new Position(4, 4));
            context["RobotSimulator"] = new RobotSimulator(surface);
        }
    }
}
