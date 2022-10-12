using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public class ObjectInstallation
    {
        private readonly int _minimumDistance;
        private static Random rand;
        private readonly Maze _maze;
        private readonly ExitFinder _exitFinder;

        public ObjectInstallation(Maze maze, int minimumDistance)
        {
            rand = new Random();
            _minimumDistance = minimumDistance; 
            _maze = maze;
            _exitFinder = new ExitFinder(maze);
        }

        public Coordinate LocateObject()
        {
            if (_minimumDistance < 1)
                throw new ArgumentException($"{nameof(_minimumDistance)} must be greater than 0");

            List<Coordinate> freeCells = new List<Coordinate>();

            if (_exitFinder.ExitCoordinate.X == 0)
            {
                for (int i = 0 + _minimumDistance; i < _maze.Map.Length - 1; i++)
                {
                    for (int j = 1; j < _maze.Map[i].Length - 1; j++)
                    {
                        if (_maze.Map[i][j] == Cells.Empty)
                        {
                            freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            else if (_exitFinder.ExitCoordinate.X == _maze.Map.Length - 1)
            {
                for (int i = _maze.Map.Length - _minimumDistance - 1; i > 0; i--)
                {
                    for (int j = 1; j < _maze.Map[i].Length - 1; j++)
                    {
                        if (_maze.Map[i][j] == Cells.Empty)
                        {
                            freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            else if (_exitFinder.ExitCoordinate.Y == 0)
            {
                for (int i = 1; i < _maze.Map.Length - 1; i++)
                {
                    for (int j = 0 + _minimumDistance; j < _maze.Map[i].Length - 1; j++)
                    {
                        if (_maze.Map[i][j] == Cells.Empty)
                        {
                            freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            else if (_exitFinder.ExitCoordinate.Y == _maze.Map.Length - 1)
            {
                for (int i = 1; i < _maze.Map.Length - 1; i++)
                {
                    for (int j = _maze.Map.Length - _minimumDistance - 1; j > 0; j--)
                    {
                        if (_maze.Map[i][j] == Cells.Empty)
                        {
                            freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }
            
            return freeCells[rand.Next(0, freeCells.Count)];
        }
    }
}
