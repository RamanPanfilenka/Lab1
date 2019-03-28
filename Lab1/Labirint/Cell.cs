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

        /// <summary>
        /// Wall - Spetificator == 0, 
        /// Pass - Spetificator == 1,
        /// Coin - Spetificator == 2,
        /// Exit - Spetificator == 3. 
        /// </summary>
        public int Spetificator { get; set; }

        public Cell(int X, int Y, int spec)
        {
            this.X = X;
            this.Y = Y;
            Spetificator = spec;
        }
    }
}
