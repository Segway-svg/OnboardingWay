using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace OnboardingWay
{
    public class MazePrinter
    {
        private readonly Maze _maze;
        private readonly Coordinate _objectCoordinate;

        public MazePrinter(Maze maze)
        {
            _maze = maze;
        }

        public MazePrinter(Maze maze, Coordinate objectCoordinate)
        {
            _maze = maze;
            _objectCoordinate = objectCoordinate;
        }

        public void PrintMaze()
        {
            for (int i = 0; i < _maze.Size; i++)
            {
                for (int j = 0; j < _maze.Size; j++)
                {
                    if (i == _objectCoordinate.X && j == _objectCoordinate.Y && i != 0 && j != 0)
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(CellToString(_maze.Map[i][j]));
                    }
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        private string CellToString(Cells cellType)
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
