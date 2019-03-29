using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    class GeneratorLabirint
    {
        Labirint lab = new Labirint();
        List<Cell> NotPassCell = new List<Cell>();
        Stack<Cell> PassCell = new Stack<Cell>();

        public Cell StartCell;
        public Cell StopCell;

        public int Wigth { get; private set; }
        public int Height { get; private set; }

        private Random random = new Random();

        /// <summary>
        /// Use default Wigth = 35 and Heigth = 15
        /// </summary>
        /// <param name="Wigth"></param>
        /// <param name="Height"></param>
        public GeneratorLabirint(int Wigth = 35, int Height = 15)
        {
            this.Height = Height;
            this.Wigth = Wigth;
        }

        /// <summary>
        /// Generate maze. Start with cell with X and Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Labirint Generate( int X = 0, int Y = 0)
        {
            lab = new Labirint(Wigth, Height);
            //All cells with spetificator == 1 is add to NotPassCell
            foreach (var cell in lab.Cells)
            {
                if ((cell.spetificator == Cell.Spetificator.Pass))
                    NotPassCell.Add(cell);
            }
            //Random first cell
            if (X == 0 && Y == 0)
            {
                while (true)
                {
                    X = random.Next(Wigth - 1) + 1;
                    Y = random.Next(Height - 1) + 1;
                    if (lab[X,Y].spetificator == Cell.Spetificator.Pass)
                    {
                        NotPassCell.Remove(lab[X,Y]);
                        break;
                    }
                }
            }
            Cell currentCell = lab[X,Y];
            StartCell = currentCell;
            while (NotPassCell.Count != 0)
            {
                List<Cell> NearCells = FindNear(currentCell.X, currentCell.Y);
                while (NearCells.Count == 0)
                {
                    currentCell = PassCell.Pop();
                    X = currentCell.X;
                    Y = currentCell.Y;
                    NearCells = FindNear(X, Y);
                    if (PassCell.Count == 0)
                        break;
                }
                //The choice direction
                int direct = random.Next(NearCells.Count);
                PassCell.Push(currentCell);
                if (NearCells.Count != 0) DeleteWall(currentCell, NearCells[direct]);
                if (NearCells.Count != 0) currentCell = NearCells[direct];
                NotPassCell.Remove(currentCell);
            }
            StopCell = currentCell;
            currentCell.spetificator = Cell.Spetificator.Exit;
            lab = GenerateCoins(lab);
            return lab;
        }

        /// <summary>
        /// Find near cells
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private List<Cell> FindNear(int X, int Y)
        {
            List<Cell> Near = new List<Cell>();
            //Upper
            if (NotPassFind(X, Y - 2) != null)
                Near.Add(NotPassFind(X, Y - 2));
            //Rigth
            if (NotPassFind(X + 2, Y) != null)
                Near.Add(NotPassFind(X + 2, Y));
            //Down
            if (NotPassFind(X, Y + 2) != null)
                Near.Add(NotPassFind(X, Y + 2));
            //Left
            if (NotPassFind(X - 2, Y) != null)
                 Near.Add(NotPassFind(X - 2, Y));
            return Near;
        }

        /// <summary>
        /// Delete walls between two cells
        /// </summary>
        /// <param name="firstCell"></param>
        /// <param name="secondCell"></param>
        private void DeleteWall(Cell firstCell, Cell secondCell)
        {
            //Second Cell is Left
            if ((firstCell.X - secondCell.X) > 0)
            {
                lab[firstCell.X - 1, firstCell.Y].spetificator = Cell.Spetificator.Pass;
            }
            else
            {
                //Second Cell is Rigth
                if ((firstCell.X - secondCell.X) < 0)
                {
                    lab[firstCell.X + 1, firstCell.Y].spetificator = Cell.Spetificator.Pass;
                }
                else
                {
                    //Second Cell is Upper
                    if ((firstCell.Y - secondCell.Y) > 0)
                    {
                        lab[firstCell.X, firstCell.Y - 1].spetificator = Cell.Spetificator.Pass;
                    }
                    else
                        //Second Cell is Down
                       lab[firstCell.X, firstCell.Y + 1].spetificator = Cell.Spetificator.Pass;
                }
            }
        }

        /// <summary>
        /// Generate 5 coins in maze.
        /// </summary>
        /// <param name="lab"></param>
        /// <returns></returns>
        private Labirint GenerateCoins(Labirint lab)
        {
            int i = 0;
            while (i < 5)
            {
                int X = random.Next(lab.Width - 1) + 1;
                int Y = random.Next(lab.Height - 1) + 1;
                if (lab[X,Y].spetificator == Cell.Spetificator.Pass)
                {
                    lab[X,Y].spetificator = Cell.Spetificator.Coin;
                    i++;
                }
            }
            return lab;
        }

        /// <summary>
        /// Return Cell in NotPassCells with X and Y
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private Cell NotPassFind(int X, int Y)
        {
            return NotPassCell.FirstOrDefault(cell => cell.X == X && cell.Y == Y);
        }
    }
}
