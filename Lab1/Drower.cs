using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Drower
    {
        public static void Drow(Labirint lab, Hero hero)
        {
            Console.WriteLine("Welcome to simple maze!");
            Console.WriteLine("Some rules: ");
            Console.WriteLine("     You're X. Your task is find exit from the maze.");
            Console.WriteLine("     Exit is marked with a symbol >.");
            Console.WriteLine("     In maze you can find coins, that will be increase your score. Good luck!");
            Console.WriteLine("Use Arrows or WASD to move ");
            Console.WriteLine("Press R - to rebuild maze(Score and Level will be reset).");
            Console.WriteLine("Press ESC - to exit from application.");
            Console.WriteLine($"Score: {hero.Score}");
            Console.WriteLine($"Level: {hero.Level}");
            for (int y = 0; y < lab.Height; y++)
            { 
                Console.WriteLine();
                for (int x = 0; x < lab.Width; x++)
                {
                    if ((x == hero.X) && (y == hero.Y))
                    {
                        Console.Write(hero.Symbol);
                    }
                    else
                    {
                        if (lab[x,y].Spetificator == 0) Console.Write("#");
                        else
                        {
                            if (lab[x,y].Spetificator == 2)
                                Console.Write("c");
                            else
                            {
                                if (lab[x,y].Spetificator == 3)
                                    Console.Write(">");
                                else
                                    Console.Write(".");
                            }
                        }
                    }
                }  
            }
        }
    }
}
