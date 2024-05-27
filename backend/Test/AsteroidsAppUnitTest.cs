using Application;
namespace Test;

public class AsteroidsAppUnitTest
{
    [Theory]
    [InlineData(new int[]{5, 10, -5}, new int[]{5, 10})]
    [InlineData(new int[]{}, new int[]{})]
    [InlineData(new int[]{8, -8}, new int[]{})]
    [InlineData(new int[]{10, 2, -5}, new int[]{10})]
    public void SimulateAsteroids(int[] given, int[] expected)
    {
        var app = new Application.AsteroidsApp();
        var actual = app.AsteroidsSimulator(given);
        Assert.Equal(expected, actual);
    }
}