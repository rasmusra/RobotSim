using RobotSim.Domain;
using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class When(ScenarioContext context)
    {
        [When(@"I issue the command '(.*)'")]
        public void Act(string command)
        {
            (context["RobotSimulator"] as RobotSimulator)!.Process(command);
        }
    }
}
