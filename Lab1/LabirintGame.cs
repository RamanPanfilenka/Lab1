using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class LabirintGame
    {
        static void Main(string[] args)
        {
            GeneratorLabirint generator = new GeneratorLabirint();
            var lab = generator.Generate();
            var hero = Hero.GetHero(generator.StartCell.X, generator.StartCell.Y);
            Drower.Drow(lab, hero);
            ConsoleKeyInfo key;
            bool work = true;
            do
            {
                bool canMove = false;
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        lab = generator.Generate();
                        hero = Hero.GetHero(generator.StartCell.X, generator.StartCell.Y);
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        canMove = Rules.CanMove(hero.X - 1, hero.Y, lab);
                        if (canMove)
                            hero.X -= 1; 
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        canMove = Rules.CanMove(hero.X + 1, hero.Y, lab);
                        if (canMove)
                            hero.X += 1;
                        break;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        canMove = Rules.CanMove(hero.X, hero.Y - 1, lab);
                        if (canMove)
                            hero.Y -= 1;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        canMove = Rules.CanMove(hero.X, hero.Y + 1, lab);
                        if (canMove)
                            hero.Y += 1;
                        break;

                    case ConsoleKey.Escape:
                        work = false;
                        break;
                }
                if (lab[hero.X,hero.Y].Spetificator == 2)
                {
                    lab[hero.X, hero.Y].Spetificator = 1;
                    hero.Score++;
                }
                if (hero.X == generator.StopCell.X && hero.Y == generator.StopCell.Y)
                {
                    lab = generator.Generate(hero.X, hero.Y);
                    Console.Clear();
                    hero.Level++;
                }
                Drower.Drow(lab, hero);
                
            }
            while (work);
            Environment.Exit(0);
            Console.Read();
        }
    }
}
