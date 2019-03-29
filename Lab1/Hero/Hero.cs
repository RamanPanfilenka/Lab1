using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Hero
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Score { get; set; } = 0;
        public int Level { get; set; } = 0;

        public string Symbol { get; set; } = "X";

        private static Hero hero;

        /// <summary>
        /// Return only one object of hero with positioin X and Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static Hero GetHero(int X, int Y)
        {  
            if (hero == null) hero = new Hero(X ,Y); 
            return hero;
        }

        private Hero(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
