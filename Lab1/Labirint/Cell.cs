using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Cell
    {
        public int X { get; }
        public int Y { get; }

        public Spetificator spetificator { get; set; }

        /// <summary>
        /// Create Cell with cordinate X and Y and Spetificator
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="spec"></param>
        public Cell(int X, int Y, Spetificator spec)
        {
            this.X = X;
            this.Y = Y;
            spetificator = spec;
        }

        public enum Spetificator
        {
            Wall,
            Pass,
            Coin,
            Exit
        }
    }
}
