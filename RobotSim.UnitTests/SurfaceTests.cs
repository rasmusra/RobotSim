using RobotSim.Model;
using Xunit;

namespace RobotSim.UnitTests;

public class SurfaceTests
{
    [Fact]
    public void WhenCreated_GivenCornerPositions_ThenCornerPositionsAreInBounds()
    {
        var p1 = new Position(0, 0);
        var p2 = new Position(4, 4);
        var surface = new Surface(p1, p2);

        Assert.True(surface.InBounds(p1));
        Assert.True(surface.InBounds(p2));  
    }
}