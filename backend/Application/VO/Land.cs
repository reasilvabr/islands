namespace Application.VO;

public class Land
{
    public Land(int line, int column)
    {
        this.Line = line;
        this.Column = column;
    }
    public int Line { get; set; }
    public int Column { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Land && obj != null)
        {
            var landToCompare = (Land)obj;
            return landToCompare.Line == this.Line && landToCompare.Column == this.Column;
        }
        return false;
    }

    public int[] ToArray(){
        return new int[] { this.Line, this.Column };
    }
}