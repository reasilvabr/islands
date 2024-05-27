using System.Collections;
using Application.VO;

namespace Test;

public class TestIslandGenerator: IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>{
        new object[] { new Island(new Land(0,0)), new Land(0, 1), true},
        new object[] { new Island(new Land(0,0)), new Land(0, 1), true},
        new object[] { new Island(new Land(1,1)), new Land(2, 1), true},
        new object[] { new Island(new Land(1,0)), new Land(0, 0), true},
        new object[] { new Island(new Land(0,0)), new Land(0, 2), false}
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}