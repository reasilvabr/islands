using Application.Interface;
using Application.VO;

namespace Application;

public class IslandsApp : IIslandsApp
{
    public List<Land> GetLands(int[][] world)
    {
        var ret = new List<Land>();
        for (int i = 0; i < world.Length; i++)
        {
            for (int j = 0; j < world[i].Length; j++)
            {
                if (world[i][j] == 1)
                {
                    ret.Add(new Land(i, j));
                }
            }
        }
        return ret;
    }

    public List<Island> IdentifyIslands(List<Land> lands)
    {
        var ret = new List<Island>();
        ret.Add(new Island(lands[0]));
        for(int i = 1; i < lands.Count(); i++)
        {
            if(IslandContainsLand(ret.Last(), lands[i]))
            {
                ret.Last().Lands.Add(lands[i]);
            }
            else
            {
                ret.Add(new Island(lands[i]));
            }
        }
        
        return ret;
    }

    public bool IslandContainsLand(Island island, Land land)
    {
        var up = new Land(land.Line - 1, land.Column);
        var down = new Land(land.Line + 1, land.Column);
        var left = new Land(land.Line, land.Column - 1);
        var right = new Land(land.Line, land.Column + 1);
        return island.Contains(up) || island.Contains(down) || island.Contains(left) || island.Contains(right);
    }
}
