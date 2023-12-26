using RobotSim.Domain;
using TechTalk.SpecFlow;

namespace RobotSim.AcceptanceTests.Steps
{
    [Binding]
    internal class Given(ScenarioContext context)
    {
        [Given(@"the surface is a table with dimensions:")]
        public void CreateSurface(Table table)
        {
            var row = table.Rows[0];
            var p1 = new Position(0, int.Parse(row["height"]) - 1);
            var p2 = new Position(int.Parse(row["width"])-1, 0);
            context["Surface"] = new Surface(p1, p2);
        }

        [Given("the robot is off the table")]
        public void RemoveAnyRobot()
        {
            var reports = new List<string>();
            context["Reports"] = reports; 
            context["RobotSimulator"] = new RobotSimulator(
                (context["Surface"] as Surface)!, reports.Add);
        }
    }
}
