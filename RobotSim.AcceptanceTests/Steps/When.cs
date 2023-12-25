using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class When
    {
        private readonly ScenarioContext context;

        public When(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I issue the command '(.*)'")]
        public void Act(string command)
        {
            // TODO: Implement this step
        }
    }
}
