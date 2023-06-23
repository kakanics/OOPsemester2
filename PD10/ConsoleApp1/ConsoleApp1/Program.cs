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
            drawGrid(grid);
            PacmanPlayer pacman = new PacmanPlayer(5, 5, grid);
            Ghost_Horizontal ghost1 = new Ghost_Horizontal(HorizontalDirections.RIGHT ,8 ,8,grid);
            Ghost_Vertical ghost2 = new Ghost_Vertical(VerticalDirections.UP, 8, 8, grid);
            Ghost_Random ghost3 = new Ghost_Random(8, 8, grid);
            Ghost_Smart ghost4 = new Ghost_Smart(20,20, grid,pacman);
            List<GameObject> gameCharacters = new List<GameObject>() { ghost1, ghost2, ghost3, ghost4, pacman };
            List<Ghost> ghosts = new List<Ghost> { ghost1, ghost2, ghost3, ghost4 };

            while (true)
            {
                Thread.Sleep(100);
                foreach(var i in gameCharacters)
                {
                    Console.SetCursorPosition(i.getCurrentCell().getX(), i.getCurrentCell().getY());
                    Console.Write(' ');
                }
                foreach (var i in ghosts)
                {
                    Console.SetCursorPosition(i.getCurrentCell().getX(), i.getCurrentCell().getY());
                    Console.Write(i.getCharAtCurrentPlace(grid));
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.W))
                {
                    pacman.move(Directions.UP);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.S))
                {
                    pacman.move(Directions.DOWN);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.A))
                {
                    pacman.move(Directions.LEFT);
                }
                if (EZInput.Keyboard.IsKeyPressed(EZInput.Key.D))
                {
                    pacman.move(Directions.RIGHT);
                }
                foreach(var i in ghosts) 
                {
                    i.Move();
                }
                foreach (var i in gameCharacters)
                {
                    Console.SetCursorPosition(i.getCurrentCell().getX(), i.getCurrentCell().getY());
                    Console.Write(i.getDisplayChar());
                }
                printScore(pacman);
            }
        }
        static void drawGrid(Grid grid)
        {
            for (int i = 0; i < grid.getRows(); i++)
            {
                for (int j = 0; j < grid.getColumns(); j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(grid.getCell(i, j).GetGameObject().getDisplayChar());
                }
            }
        }
        static void printScore(PacmanPlayer pacman)
        {
            Console.SetCursorPosition(100, 5);
            Console.Write("SCORE: {0}", pacman.getScore());
        }
    }
}
