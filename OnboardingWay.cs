using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;
using OnboardingWay;

public class Program
{
    public static void Main(string[] args)
    {
        int size = 5;
        IMapGenerator generator = new GrowingTreeGenerator();
        var maze = new Maze(generator.Generate(size));
        maze.AddExit();

        ObjectGenerator objectGenerator = new ObjectGenerator(maze, 5);
        objectGenerator.GenerateObjectAndShowMaze();
    }
}