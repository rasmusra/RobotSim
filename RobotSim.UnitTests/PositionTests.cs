using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests;

public class PositionTests
{
    [Fact]
    public void WhenCreated_GivenPosition_ThenCoordinatesAreAvailable()
    {
        const int x = 5;
        const int y = 5;

        var position = new Position(x, y);

        Assert.Equal(x, position.X);
        Assert.Equal(y, position.Y);
    }
}