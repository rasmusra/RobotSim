using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Given
    {
        private readonly ScenarioContext context;

        public Given(ScenarioContext context)
        {
            this.context = context;
        }

        [Given("the robot is off the table")]
        public void RemoveAnyRobot()
        {
            context["Robot"] = null;
        }
    }
}
