using TechTalk.SpecFlow;
using Xunit;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Then
    {
        private readonly ScenarioContext context;

        public Then(ScenarioContext context)
        {
            this.context = context;
        }

        [Then("the robot is on the table at position '(.*)' facing '(.*)'")]
        public void AssertRobotState(string position, string cardinalDirection)
        {
            // TODO: Implement this step
            Assert.Fail("Not implemented");
         }
    }
}
