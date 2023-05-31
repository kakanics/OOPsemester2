using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PDgrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid("maze.txt", 9, 9);
            Ghost ghost1 = new Ghost(5,5,"up",2,'s','G',0.2f,grid);
            Ghost ghost2 = new Ghost(6,5,"right",2,'s','G',0.2f,grid);
            Ghost ghost3 = new Ghost(7,6,"right",2,'s','G',0.2f,grid);
            Ghost ghost4 = new Ghost(6,6,"right",2,'s','G',0.2f,grid);
            Pacman player = new Pacman(2, 2, 0, grid);
            grid.maze[2, 2].value = 'P';
            grid.maze[5, 6].value = 'G';

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            grid.draw();

            while (true)
            {
            Thread.Sleep(200);
                foreach (var i in enemies)
                {
                    i.remove();
                    i.moveHorizontal();
                    i.moveVertical();
                    i.draw();
                }
                ghost3.remove();
                ghost4.remove();
                ghost3.MoveRandom();
                ghost4.MoveSmart();
                player.draw();
                ghost3.draw();
                ghost4.draw();
                if (grid.maze[2, 2].value != 'P') break;
                grid.draw();
            }
            Console.ReadKey();
        }
    }
}
