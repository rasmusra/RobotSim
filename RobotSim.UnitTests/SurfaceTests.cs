using RobotSim.Domain;
using Xunit;

namespace RobotSim.UnitTests;

public class SurfaceTests
{
    [Theory]
    [InlineData(0, 0, 4, 4)]
    [InlineData(4, 4, 0, 0)]
    [InlineData(4, 0, 4, 0)]
    [InlineData(4, 0, 0, 4)]
    [InlineData(4, 4, 0, 4)]
    public void WhenCreated_GivenCornerPositions_ThenCornerPositionsAreInBounds(
        uint x1, uint y1, uint x2, uint y2)
    {
        var p1 = new Position(x1, y1);
        var p2 = new Position(x2, y2);
        var surface = new Surface(p1, p2);

        Assert.True(surface.InBounds(p1));
        Assert.True(surface.InBounds(p2));  
    }
}