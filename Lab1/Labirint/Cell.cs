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

        /// <summary>
        /// Create Cell with cordinate X and Y and Spetificator
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="spec">Spetificator(0 - Wall, 1 - Pass, 2 - Coin, 3 - Exit)</param>
        public Cell(int X, int Y, int spec)
        {
            this.X = X;
            this.Y = Y;
            Spetificator = spec;
        }
    }
}
