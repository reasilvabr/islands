namespace Application.Interface;

public interface IAsteroidsApp{
    int[] AsteroidsSimulator(int[] asteroids);
    int[] GetRandomData(int size = 5);
}