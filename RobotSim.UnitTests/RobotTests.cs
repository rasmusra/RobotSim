using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests;

public class RobotTests

{
    [Theory]
    [InlineData("PLACE 0,1,NORTH", 0)]
    [InlineData("PLACE 0,1,EAST", 90)]
    [InlineData("PLACE 0,1,SOUTH", 180)]
    [InlineData("PLACE 0,1,WEST", 270)]
    public void WhenParsingState_GivenStateIsValid_ThenNewRobotIsReturned(
        string placementData, uint expectedDegrees)
    {
        var robot = Robot.Parse(placementData);

        Assert.Equal((uint)0, robot!.Position.X);
        Assert.Equal((uint)1, robot.Position.Y);
        Assert.Equal(expectedDegrees, robot.Degrees);
    }
}