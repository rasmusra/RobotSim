using RobotSim.Model;
using Xunit;

namespace RobotSim.UnitTests;

public class SurfaceTests
{
    [Fact]
    public void WhenCreated_GivenDimension_ThenInBoundsIsAvailable()
    {
        const uint Width = 5;
        const uint Height = 5;
        var surface = new Surface(Width, Height);

        Assert.Equal(Width, surface.Width);
        Assert.Equal(Height, surface.Height);
    }
}