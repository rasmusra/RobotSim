using TechTalk.SpecFlow;
using Xunit;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Then(ScenarioContext context)
    {
        [Then("Then I see '(.*)' on the screen")]
        public void AssertRobotState(string expectedReport)
        {
            var actualReports = context["Reports"] as List<string>;
            Assert.Single(actualReports!);
            Assert.Equal(expectedReport, actualReports![0]);
        }
    }
}
