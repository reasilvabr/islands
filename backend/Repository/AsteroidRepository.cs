using Repository.Interface;
namespace Repository;

public class AsteroidRepository : IAsteroidRepository
{
    public int[] GetRandomData(int size = 5)
    {
        var data = new int[size];
        for (var i = 0; i < size; i++)
        {
            var num = 0;
            var rand = new Random();
            while (num == 0)
            {
                num = rand.Next(-10, 10);
            }
            data[i] = num;
        }
        return data;
    }
}
