using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public class ObjectGenerator
    {
        private Coordinate _exitCoordinate;
        private static Random rand = new Random();


        private readonly Maze maze;
        private readonly int minimumDistance;
        private readonly List<Coordinate> _freeCells = new List<Coordinate>();

        public ObjectGenerator(Maze maze, int minimumDistance)
        {
            this.maze = maze;
            this.minimumDistance = minimumDistance;
        }

        public void GenerateObjectAndShowMaze()
        {
            FindExit();
            LocateObject();
            PrintMaze();
        }

        public void FindExit()
        {
            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    if (maze.Map[i][j] == Cells.Exit)
                    {
                        _exitCoordinate = new Coordinate(i, j);
                    }
                }
            }
        }

        public void LocateObject()
        {
            if (_exitCoordinate.X == 0)
            {
                Console.WriteLine("1");
                for (int i = 0 + minimumDistance; i < maze.Map.Length - 1; i++)
                {
                    for (int j = 1; j < maze.Map[i].Length - 1; j++)
                    {
                        if (maze.Map[i][j] == Cells.Empty)
                        {
                            _freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            if (_exitCoordinate.X == maze.Map.Length - 1)
            {
                Console.WriteLine("2");
                for (int i = maze.Map.Length - minimumDistance - 1; i > 0; i--)
                {
                    for (int j = 1; j < maze.Map[i].Length - 1; j++)
                    {
                        if (maze.Map[i][j] == Cells.Empty)
                        {
                            _freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            if (_exitCoordinate.Y == 0)
            {
                Console.WriteLine("3");
                for (int i = 1; i < maze.Map.Length - 1; i++)
                {
                    for (int j = 0 + minimumDistance; j < maze.Map[i].Length - 1; j++)
                    {
                        if (maze.Map[i][j] == Cells.Empty)
                        {
                            _freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }

            if (_exitCoordinate.Y == maze.Map.Length - 1)
            {
                Console.WriteLine("4");
                for (int i = 1; i < maze.Map.Length - 1; i++)
                {
                    for (int j = maze.Map.Length - minimumDistance - 1; j > 0; j--)
                    {
                        if (maze.Map[i][j] == Cells.Empty)
                        {
                            _freeCells.Add(new Coordinate(i, j));
                        }
                    }
                }
            }
        }

        public void PrintMaze()
        {
            Coordinate finalCoordinate = _freeCells[rand.Next(0, _freeCells.Count)];

            Console.WriteLine(_freeCells.Count);

            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    if (i == finalCoordinate.X && j == finalCoordinate.Y)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(CellToString(maze.Map[i][j]));
                    }

                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        } 

        public string CellToString(Cells cellType)
        {
            return cellType switch
            {
                Cells.Wall => "0",
                Cells.Empty => " ",
                Cells.Exit => "#",
                _ => throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null)
            };
        }
    }
}
