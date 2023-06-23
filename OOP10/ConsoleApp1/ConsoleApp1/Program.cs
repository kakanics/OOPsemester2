using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid("maze.txt");
            for(int i = 0; i < grid.getRows(); i++)
            {
                for(int j = 0; j < grid.getColumns(); j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.Write(grid.getCell(i,j).GetGameObject().getDisplayChar());
                }
            }
            PacmanPlayer pacman = new PacmanPlayer(5, 5, grid);
            while(true)
            {
                Thread.Sleep(100);
                if(EZInput.Keyboard.IsKeyPressed(EZInput.Key.W))
                {
                    pacman.move(directions.UP);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.S))
                {
                    pacman.move(directions.DOWN);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.A))
                {
                    pacman.move(directions.LEFT);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.D))
                {
                    pacman.move(directions.RIGHT);
                }
                Console.SetCursorPosition(pacman.getCurrentCell().getX(), pacman.getCurrentCell().getY());
                Console.Write('P');
            }
        }
    }
}
