using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Rules
    {
        /// <summary>
        /// Check posibility of move
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="lab"></param>
        /// <returns></returns>
        public static bool CanMove(int X, int Y, Labirint lab)
        {
            if (lab[X,Y].Spetificator == 0)
                return false;
            return true;
        }
    }
}
