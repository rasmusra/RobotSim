using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests;

public class RobotTests
{
    [Theory]
    [InlineData("PLACE 0,0")]
    [InlineData("PLACE 0,0,OOPS")]
    [InlineData("PLACE")]
    public void WhenTryToCreate_GivenBadFormat_ThenFalseIsReturned(string badFormatOfPlacementData)
    {
        var robotOk = Robot.TryParse(badFormatOfPlacementData, out var robot);

        Assert.False(robotOk);
        Assert.Null(robot);
    }

    [Theory]
    [InlineData("PLACE 0,1,NORTH", 0)]
    [InlineData("PLACE 0,1,EAST", 90)]
    [InlineData("PLACE 0,1,SOUTH", 180)]
    [InlineData("PLACE 0,1,WEST", 270)]
    public void WhenParsingState_GivenStateIsValid_ThenNewRobotIsReturned(
        string placementData, int expectedDegrees)
    {
        var robotOk = Robot.TryParse(placementData, out var robot);

        Assert.True(robotOk);
        Assert.Equal(0, robot!.Position.X);
        Assert.Equal(1, robot.Position.Y);
        Assert.Equal(expectedDegrees, robot.Degrees);
    }

    [Theory]
    [InlineData("PLACE 2,2,NORTH", 2, 3)]
    [InlineData("PLACE 2,2,EAST", 3, 2)]
    [InlineData("PLACE 2,2,SOUTH", 2, 1)]
    [InlineData("PLACE 2,2,WEST", 1, 2)]
    public void WhenMoving_GivenRobotIsPlacedInMiddle_ThenRobotIsMoved(
        string placementData, int expectedX, int expectedY)
    {
        var robotOk = Robot.TryParse(placementData, out var robot);
        robot!.Move();

        Assert.True(robotOk);
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
        var robotOk = Robot.TryParse(placementData, out var robot);
        var actual = robot!.ToString();

        Assert.True(robotOk);
        Assert.Equal(expectedString, actual);
    }

    [Theory]
    [InlineData("PLACE 2,2,NORTH", 270)]
    [InlineData("PLACE 2,2,EAST", 0)]
    [InlineData("PLACE 2,2,SOUTH", 90)]
    [InlineData("PLACE 2,2,WEST", 180)]
    public void WhenTurningLeft_GivenPosition_ThenExpectedDirectionIsSet(
        string placementData, int expectedDegrees)
    {
        var robotOk = Robot.TryParse(placementData, out var robot);
        robot!.TurnLeft();

        Assert.True(robotOk);
        Assert.Equal(expectedDegrees, robot.Degrees);
    }

    [Theory]
    [InlineData("PLACE 2,2,NORTH", 90)]
    [InlineData("PLACE 2,2,EAST", 180)]
    [InlineData("PLACE 2,2,SOUTH", 270)]
    [InlineData("PLACE 2,2,WEST", 0)]
    public void WhenTurningRight_GivenPosition_ThenExpectedDirectionIsSet(
        string placementData, int expectedDegrees)
    {
        var robotOk = Robot.TryParse(placementData, out var robot);
        robot!.TurnRight();

        Assert.True(robotOk);
        Assert.Equal(expectedDegrees, robot.Degrees);
    }

}