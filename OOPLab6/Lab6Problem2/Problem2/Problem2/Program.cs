using Problem2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem2
{
    internal class Program
    {
        public static char[,] shape = { { '*',  '*' , '*'} 
                                        ,{ ' ', '*', ' '} };
        static void Main(string[] args)
        {
            GameObject g1 = new GameObject(shape, new Point(20,20), new Boundary(), "LeftToRight");
            GameObject g2 = new GameObject(shape, new Point(20,20), new Boundary(), "RightToLeft");
            GameObject g3 = new GameObject(shape, new Point(20,10), new Boundary(), "PatrolR");
            GameObject g4 = new GameObject(shape, new Point(20,20), new Boundary(), "Projectile");
            GameObject g5 = new GameObject(shape, new Point(20,20), new Boundary(), "Diagnol");
            while(true)
            {
                Thread.Sleep(100);
                g1.erase();
                g1.Move();
                g1.draw();

                g2.erase();
                g2.Move();
                g2.draw();

                g3.erase();
                g3.Move();
                g3.draw();

                g4.erase();
                g4.Move();
                g4.draw();

                g5.erase();
                g5.Move();
                g5.draw();
            }
        }
    }
}
