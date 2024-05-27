using Application;
using Application.Interface;
using Application.VO;
namespace Test;

public class IslandsAppUnitTest
{
    readonly IIslandsApp _app;

    public IslandsAppUnitTest(){
        _app = new IslandsApp();
    }

    [Fact]
    public void GetLands()
    {
        var given = new int[][]{
            new int[] {1, 1, 0, 0, 0},
            new int[] {1, 1, 0, 0, 0},
            new int[] {0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 1, 1}
        };
        var expected = new List<Land>{
            new Land(0, 0),
            new Land(0, 1),
            new Land(1, 0),
            new Land(1, 1),
            new Land(2, 2),
            new Land(3, 3),
            new Land(3, 4)
            };
        var actual = _app.GetLands(given);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IdentifyIslands()
    {
        var given = new List<Land>{
            new Land(0, 0),
            new Land(0, 1),
            new Land(1, 0),
            new Land(1, 1),
            new Land(2, 2),
            new Land(3, 3),
            new Land(3, 4)};
        var expected = new List<Island>{
            new Island(
                new Land(0, 0),
                new Land(0, 1),
                new Land(1, 0),
                new Land(1, 1)
            ),
            new Island(
                new Land(2, 2)
            ),
            new Island(
                new Land(3, 3),
                new Land(3, 4)
            )
        };
        var actual = _app.IdentifyIslands(given);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(TestIslandGenerator))]
    public void IslandContainsLand(Island givenIsland, Land givenLand, bool expected)
    {
        var app = new IslandsApp();
        var actual = _app.IslandContainsLand(givenIsland, givenLand);
        Assert.Equal(expected, actual);
    }
}