using System.Threading.Channels;
using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public  class MazeRunner
    {
        private Maze _maze;
        private int _visibility;
        private Coordinate _objectCoordinate;
        private readonly ExitFinder _exitFinder;

        public MazeRunner(Maze maze, int visibility, Coordinate objectCoordinate)
        {
            _maze = maze;
            _visibility = visibility; 
            _objectCoordinate = objectCoordinate;
            _exitFinder = new ExitFinder(maze);
        }

        public void Moving()
        {
            while (_objectCoordinate.X != _exitFinder.ExitCoordinate.X || _objectCoordinate.Y != _exitFinder.ExitCoordinate.Y)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.W:
                        _objectCoordinate += new Coordinate(-1, 0);
                        if (_maze.Map[_objectCoordinate.X][_objectCoordinate.Y] == Cells.Wall)
                        {
                            _objectCoordinate += new Coordinate(1, 0);
                        }
                        break;
                    case ConsoleKey.A:
                        _objectCoordinate += new Coordinate(0, -1);
                        if (_maze.Map[_objectCoordinate.X][_objectCoordinate.Y] == Cells.Wall)
                        {
                            _objectCoordinate += new Coordinate(0, +1);
                        }
                        break;
                    case ConsoleKey.S:
                        _objectCoordinate += new Coordinate(1, 0);
                        if (_maze.Map[_objectCoordinate.X][_objectCoordinate.Y] == Cells.Wall)
                        {
                            _objectCoordinate += new Coordinate(-1, 0);
                        }
                        break;
                    case ConsoleKey.D:
                        _objectCoordinate += new Coordinate(0, 1);
                        if (_maze.Map[_objectCoordinate.X][_objectCoordinate.Y] == Cells.Wall)
                        {
                            _objectCoordinate += new Coordinate(0, -1);
                        }
                        break;
                }

                Console.Clear();
                MazePrinter mazePrinter = new MazePrinter(_maze, _objectCoordinate);
                mazePrinter.PrintMaze();
            }

            Console.WriteLine("You have reached the finish! Congratulations!");
        }
    }
}
