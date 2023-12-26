using TechTalk.SpecFlow;
using Xunit;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Then(ScenarioContext context)
    {
        [Then("I see '(.*)' on the screen")]
        public void AssertRobotState(string expectedReport)
        {
            var actualReports = context["Reports"] as List<string>;
            Assert.Single(actualReports!);
            Assert.Equal(expectedReport, actualReports![0]);
        }
        [Then("I see nothing on the screen")]
        public void AssertNothingIsReported()
        {
            var actualReports = context["Reports"] as List<string>;
            Assert.Empty(actualReports!);
        }
        [Then("I see the following output:")]
        public void AssertRobotState(Table table)
        {
            var expectedReports = table.Rows.Select(r => r["report"]);
            var actualReports = context["Reports"] as List<string>;
            Assert.Equal(expectedReports, actualReports!);
        }
        
    }
}
