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

        ObjectInstallation objectInstallation = new ObjectInstallation(maze, 5); 
        Coordinate objectCoordinate = objectInstallation.LocateObject();

        MazePrinter mazePrinter = new MazePrinter(maze, objectCoordinate);
        mazePrinter.PrintMaze();
    }
}