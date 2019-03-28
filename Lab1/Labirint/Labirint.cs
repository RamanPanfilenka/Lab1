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

        public Labirint(int Width = 25, int Height = 15)
        {
            this.Height = Height;
            this.Width = Width;


            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if ((x == 0) || (y == 0) || (x == Width - 1) || (y == Height - 1) || (x % 2 == 0) || (y % 2 == 0))
                        Cells.Add(new Cell(x, y, 0));
                    else
                        Cells.Add(new Cell(x,y,1));
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

    }
}
