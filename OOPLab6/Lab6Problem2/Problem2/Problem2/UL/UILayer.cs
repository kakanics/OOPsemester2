using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.UL
{
    internal class UILayer
    {
        public static void draw(char[,] shape, int x, int y)
        {
            for(int i = 0; i<shape.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y+i);
                for(int j = 0; j < shape.GetLength(1);j++)
                {
                    Console.Write(shape[i,j]);
                }
            }
        }
        public static void erase(char[,] shape, int x, int y)
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
