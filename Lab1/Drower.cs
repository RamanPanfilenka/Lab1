using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Drower
    {
        /// <summary>
        /// Drow all elements in console
        /// </summary>
        /// <param name="lab">Maze</param>
        /// <param name="hero">Hero</param>
        public static void Drow(Labirint lab, Hero hero)
        {
            var str = new StringBuilder();
            str.AppendLine("Welcome to simple maze!");
            str.AppendLine("Some rules: ");
            str.AppendLine("     You're X. Your task is find exit from the maze.");
            str.AppendLine("     Exit is marked with a symbol >.");
            str.AppendLine("     In maze you can find coins, that will be increase your score. Good luck!");
            str.AppendLine("Use Arrows or WASD to move ");
            str.AppendLine("Press R - to rebuild maze(Score and Level will be reset).");
            str.AppendLine("Press ESC - to exit from application.");
            str.AppendLine($"Score: {hero.Score}");
            str.AppendLine($"Level: {hero.Level}");

            for (int y = 0; y < lab.Height; y++)
            { 
                str.AppendLine();
                for (int x = 0; x < lab.Width; x++)
                {
                    if ((x == hero.X) && (y == hero.Y))
                    {
                        str.Append(hero.Symbol);
                    }
                    else
                    {
                        if (lab[x,y].spetificator == Cell.Spetificator.Wall) str.Append("#");
                        else
                        {
                            if (lab[x,y].spetificator == Cell.Spetificator.Coin)
                                str.Append("c");
                            else
                            {
                                if (lab[x,y].spetificator == Cell.Spetificator.Exit)
                                    str.Append(">");
                                else
                                    str.Append(".");
                            }
                        }
                    }
                }  
            }

            Console.Write(str);
        }
    }
}
