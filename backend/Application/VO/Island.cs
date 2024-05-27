namespace Application.VO;

public class Island
{
    public Island()
    {
        this.Lands = new List<Land>();
    }

    public Island(params Land[] lands)
    {
        this.Lands = new List<Land>(lands);
    }

    public List<Land> Lands { get; set; }

    public bool Contains(Land land){
        return this.Lands.Contains(land);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Island && obj != null)
        {
            var islandToCompare = (Island)obj;
            if(this.Lands.Count == islandToCompare.Lands.Count)
            {
                var ret = true;
                this.Lands.ForEach(land => ret &= islandToCompare.Contains(land));
                return ret;
            }
            
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Lands.GetHashCode();
    }

    public int[][] ToArray(){
        var ret = new List<int[]>();
        Lands.ForEach(land => ret.Add(land.ToArray()));
        return ret.ToArray();
    }
}