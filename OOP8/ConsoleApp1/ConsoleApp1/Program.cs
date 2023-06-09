using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cylinder c1 = new Cylinder();
            Cylinder c2 = new Cylinder(3,4,"blue");
            Cylinder c3 = new Cylinder(4,5, "green");

            Console.WriteLine(c1.toString()+"\n"+c2.toString() + "\n"+c3.toString()+"\n");
            Console.WriteLine(c1.getVolume()+"\n"+c2.getVolume() + "\n"+c3.getVolume());
        }
    }
}
