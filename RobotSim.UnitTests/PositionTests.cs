using Xunit;
using RobotSim.Console;

namespace RobotSim.UnitTests;

public class PositionTests
{
    [Fact]
    public void WhenCreated_GivenPosition_ThenCoordinatesAreAvailable()
    {
        const uint x = 5;
        const uint y = 5;

        var position = new Position(x, y);

        Assert.Equal(x, position.X);
        Assert.Equal(y, position.Y);
    }
}