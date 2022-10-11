using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public class ObjectInstallation
    {
        private Coordinate _exitCoordinate;
        private static Random rand;
        private readonly Maze _maze;
        private readonly int _minimumDistance;

        public ObjectInstallation(Maze maze, int minimumDistance)
        {
            rand = new Random();
            _maze = maze;
            _minimumDistance = minimumDistance;
        }

        public Coordinate LocateObject()
        {
            FindExit();

            List<Coordinate> freeCells = new List<Coordinate>();

            if (_exitCoordinate.X == 0)
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

            if (_exitCoordinate.X == _maze.Map.Length - 1)
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

            if (_exitCoordinate.Y == 0)
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

            if (_exitCoordinate.Y == _maze.Map.Length - 1)
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

        private void FindExit()
        {
            for (int i = 0; i < _maze.Size; i++)
            {
                for (int j = 0; j < _maze.Size; j++)
                {
                    if (_maze.Map[i][j] == Cells.Exit)
                    {
                        _exitCoordinate = new Coordinate(i, j);
                    }
                }
            }
        }
    }
}
