namespace Repository.Interface;

public interface IAsteroidRepository
{
    int[] GetRandomData(int size = 5);
}