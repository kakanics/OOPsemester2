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
            DL.add(UL.getRectangle());
            DL.add(UL.getCircle());
            DL.add(UL.GetSquare());
            DL.add(UL.GetSquare());
            DL.add(UL.getCircle());
            DL.add(UL.getRectangle());
            Console.Clear();
            UL.output();
        }
        class DL
        {
            public static List<Shape> shapes = new List<Shape>();
            public static void add(Shape shape)
            {
                shapes.Add(shape);
            }
        }
        class UL
        {

        public static Circle getCircle()
        {
            Console.WriteLine("Enter radius");
            float radius = float.Parse(Console.ReadLine()); 
            return new Circle(radius);
        }
        public static Square GetSquare()
        {
            Console.WriteLine("Enter length");
            float l = float.Parse(Console.ReadLine());
            return new Square(l);
        }
        public static Rectangle getRectangle()
        {
            Console.WriteLine("Enter length");
            float l = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter width");
            float w= float.Parse(Console.ReadLine());
            return new Rectangle(l,w);
            }
            public static void output()
            {
                foreach (Shape shape in DL.shapes)
                {
                    Console.WriteLine(shape.ToString());
                }
            }
        }
    }
}
