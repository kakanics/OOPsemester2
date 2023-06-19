using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace PDgrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid("maze.txt", 9, 9);
            Ghost ghost1 = new Ghost(5, 5, "up", 2, 's', 'G', 0.2f, grid);
            Ghost ghost2 = new Ghost(6, 5, "right", 2, 's', 'G', 0.2f, grid);
            Ghost ghost3 = new Ghost(7, 6, "right", 2, 's', 'G', 0.2f, grid);
            Ghost ghost4 = new Ghost(6, 6, "right", 2, 's', 'G', 0.2f, grid);
            Pacman player = new Pacman(2, 2, 0, grid);

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            grid.draw();

            while (!grid.stopCondition())
            {
            Thread.Sleep(1000);
                foreach (var i in enemies)
                {
                    i.moveHorizontal();
                    i.moveVertical();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.moveRight();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.moveLeft();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    player.moveUp();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.moveDown();
                }
                ghost3.MoveRandom();
                ghost4.MoveSmart();
                grid.draw();
            }
            Console.ReadKey();
        }
    }
}
