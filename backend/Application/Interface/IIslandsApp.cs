using Application.VO;

namespace Application.Interface;

public interface IIslandsApp
{
    List<Land> GetLands(int[][] world);
    List<Island> IdentifyIslands(List<Land> lands);
    bool IslandContainsLand(Island island, Land land);
}