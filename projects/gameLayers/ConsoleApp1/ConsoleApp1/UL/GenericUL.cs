using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UL
{
    internal class GenericUL
    {
        public static void eraser(char[,] print, int x, int y)
        {
            for (int i = 0; i < print.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < print.GetLength(1); j++)
                {
                    Console.Write(' ');
                }
            }
        }
        public static void printer(char[,] print, int x, int y)
        {
            for (int i = 0; i < print.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < print.GetLength(1); j++)
                {
                    Console.Write(print[i, j]);
                }
            }
        }
        public static void printHealth(int health, int score)
        {
            Console.SetCursorPosition(80, 2);
            Console.Write("Health: {0}  ", health);
            Console.SetCursorPosition(80, 3);
            Console.Write("Score: {0}  ", score);
        }
        public static void printMaze(char[,] maze)
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 75; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void printThing(char thing, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(thing);
        }
        public static void eraseXY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }


    }
}
