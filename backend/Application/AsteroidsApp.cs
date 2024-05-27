using Application.Interface;
using Repository.Interface;

namespace Application;

public class AsteroidsApp : IAsteroidsApp
{
    private readonly IAsteroidRepository _repository;

    public AsteroidsApp(IAsteroidRepository repository)
    {
        _repository = repository;
    }

    public int[] GetRandomData(int size = 5)
    {
        return _repository.GetRandomData(size);
    }

    public int[] AsteroidsSimulator(int[] asteroids)
    {
        var ret = SimulateAsteroids(asteroids);
        while (asteroids != ret)
        {
            asteroids = ret;
            ret = SimulateAsteroids(asteroids);
        }
        return ret;
    }

    private int[] SimulateAsteroids(int[] asteroids, int pos = 0)
    {
        var asteroidsList = asteroids.ToList();
        if (asteroids.Length <= pos + 1)
        {
            return asteroids;
        }

        var currentAsteroid = asteroids[pos];
        var nextAsteroid = asteroids[pos + 1];

        if (currentAsteroid > 0 && nextAsteroid < 0 || currentAsteroid < 0 && nextAsteroid > 0)
        {
            if (Math.Abs(currentAsteroid) > Math.Abs(nextAsteroid))
            {
                asteroidsList.RemoveAt(pos + 1);
                return SimulateAsteroids(asteroidsList.ToArray(), pos + 1);
            }
            else if (Math.Abs(currentAsteroid) < Math.Abs(asteroids[0]))
            {
                asteroidsList.RemoveAt(pos);
                return SimulateAsteroids(asteroidsList.ToArray(), pos + 1);
            }
            else
            {
                asteroidsList.RemoveAt(pos + 1);
                asteroidsList.RemoveAt(pos);
                return SimulateAsteroids(asteroidsList.ToArray(), pos);
            }
        }

        return SimulateAsteroids(asteroids, pos + 1);
    }
}
