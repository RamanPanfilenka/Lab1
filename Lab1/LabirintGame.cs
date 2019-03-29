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
            var hero = Hero.GetHero();
            hero.SetPosition(generator.StartCell.X, generator.StartCell.Y);
            Drower.Drow(lab, hero);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        lab = generator.Generate();
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        lab.TryMove(hero.X - 1, hero.Y, Direction.Left);
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        lab.TryMove(hero.X + 1, hero.Y, Direction.Right);
                        break;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        lab.TryMove(hero.X, hero.Y - 1, Direction.Up);
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        lab.TryMove(hero.X, hero.Y + 1, Direction.Down);
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
                if (lab.Passed == true)
                {
                    lab = generator.Generate();
                }
                Drower.Drow(lab, hero);       
            }
            while (true);
        }
    }
}
