using RobotSim.Domain;
using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class When(ScenarioContext context)
    {
        [When(@"I issue the commands:")]
        public void Act(Table table)
        {
            var target = (context["RobotSimulator"] as RobotSimulator)!;
            foreach (var row in table.Rows)
            {
                target.Process(row["command"]);
            }
            
        }
    }
}
