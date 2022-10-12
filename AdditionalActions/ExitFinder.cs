using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public class ExitFinder
    {
        public Coordinate ExitCoordinate;

        public ExitFinder(Maze maze)
        {
            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    if (maze.Map[i][j] == Cells.Exit)
                    {
                        ExitCoordinate = new Coordinate(i, j);
                    }
                }
            }
        }
    }
}
