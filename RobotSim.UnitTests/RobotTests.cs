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
    [Theory]
    [InlineData("PLACE 2,2,NORTH", 2, 3)]
    [InlineData("PLACE 2,2,EAST", 3, 2)]
    [InlineData("PLACE 2,2,SOUTH", 2, 1)]
    [InlineData("PLACE 2,2,WEST", 1, 2)]
    public void WhenMoving_GivenRobotIsPlacedInMiddle_ThenRobotIsMoved(
        string placementData, uint expectedX, uint expectedY)
    {
        var robot = Robot.Parse(placementData)!;

        robot.Move();

        Assert.Equal(expectedX, robot.Position.X);
        Assert.Equal(expectedY, robot.Position.Y);
    }
    [Theory]
    [InlineData("PLACE 2,2,NORTH", "2,2,NORTH")]
    [InlineData("PLACE 2,2,EAST", "2,2,EAST")]
    [InlineData("PLACE 2,2,SOUTH", "2,2,SOUTH")]
    [InlineData("PLACE 2,2,WEST", "2,2,WEST")]
    public void WhenSerializingToString_GivenPosition_ThenStringRepresentationIsReturned(
        string placementData, string expectedString)
    {
        var robot = Robot.Parse(placementData)!;
        var actual = robot.ToString();
        Assert.Equal(expectedString, actual);
    }

}