using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Labirint
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Cell> Cells = new List<Cell>();
        public bool Passed = false;

        /// <summary>
        /// Create maze with Width and Height. Default Width == 35 and Height == 15
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public Labirint(int Width = 11, int Height = 9)
        {
            this.Height = Height;
            this.Width = Width;

            //Create basis for maze
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if ((x == 0) || (y == 0) || (x == Width - 1) || (y == Height - 1) || (x % 2 == 0) || (y % 2 == 0))
                        Cells.Add(new Cell(x, y, Cell.Spetificator.Wall));
                    else
                        Cells.Add(new Cell(x,y,Cell.Spetificator.Pass));
                }
            }
        }

        /// <summary>
        /// Return Cell with coordinates X and Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Cell this[int X, int Y]
        {
            get
            {
                return Cells.FirstOrDefault(cell => cell.X == X && cell.Y == Y);
            }

        }

        /// <summary>
        /// If is posible move to cell
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="direction"></param>
        public void TryMove(int X, int Y, Direction direction)
        {
            var hero = Hero.GetHero();
            var CellToMove = this[X, Y];
            if (CellToMove.spetificator != Cell.Spetificator.Wall)
            {
                switch (direction)
                {
                    case Direction.Up:
                        hero.Y -= 1;
                        break;
                    case Direction.Right:
                        hero.X += 1;
                        break;
                    case Direction.Down:
                        hero.Y += 1;
                        break;
                    case Direction.Left:
                        hero.X -= 1;
                        break;
                }
                if (CellToMove.spetificator == Cell.Spetificator.Coin)
                {
                    CellToMove.spetificator = Cell.Spetificator.Pass;
                    hero.Score++;
                }
                if (CellToMove.spetificator == Cell.Spetificator.Exit)
                {
                    Passed = true;
                    hero.Level++;
                }
            }

        }

    }
}
