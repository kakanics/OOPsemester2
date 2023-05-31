using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6Challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLine line = null;
            string choice = "0";
            while(choice != "10")
            {
                Console.Clear();
                menu();
                choice = Console.ReadLine();
                if(choice == "1")
                {
                    line = makeLine();
                }
                if (choice == "2" && line!=null)
                {
                    changeBeginPoint(line);
                }
                if (choice == "3" && line != null)
                {
                    changeEndPoint(line);
                }
                if (choice == "4" && line != null)
                {
                    showPoint(line.getBegin());
                }
                if (choice == "5" && line != null)
                {
                    showPoint(line.getEnd());
                }
                if (choice == "6" && line != null)
                {
                    getLength(line);
                }
                if (choice == "7" && line != null)
                {
                    getGradient(line);
                }
                if (choice == "8" && line != null)
                {
                    getZeroDistance(line.getBegin());
                }
                if (choice == "9" && line != null)
                {
                    getZeroDistance(line.getEnd());
                }
                Console.ReadKey();
            }
        }
        static void menu()
        {
            Console.WriteLine("1. Make a Line\n2. Update Begin point\n3. Update End point\n4. Show begin point\n5. Show end point\n6. get length of line" +
                "\n7. get gradient of line\n8. find distance of beginning from zero coordinates\n9. find distance of ending from zero coordinates\n10. Exit");
        }
        static MyLine makeLine()
        {
            int x1, x2, y1, y2;
            Console.WriteLine("Enter x1");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter y1");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter x2");
            x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter y2");
            y2 = int.Parse(Console.ReadLine());
            MyLine line = new MyLine(new MyPoint(x1, y1), new MyPoint(x2, y2));
            return line;
        }
        static void changeBeginPoint(MyLine line)
        {
            int x1, y1;
            Console.WriteLine("Enter new x");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new y");
            y1 = int.Parse(Console.ReadLine());
            MyPoint point = new MyPoint(x1, y1);
            line.setBegin(point);
        }
        static void changeEndPoint(MyLine line)
        {
            int x1, y1;
            Console.WriteLine("Enter new x");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new y");
            y1 = int.Parse(Console.ReadLine());
            MyPoint point = new MyPoint(x1, y1);
            line.setEnd(point);
        }
        static void showPoint(MyPoint point)
        {
            Console.WriteLine("The point is: " + point.getX() + "," + point.getY());
        }
        static void getLength(MyLine line)
        {
            Console.WriteLine("Length of line is: "+ line.getLength());
        }
        static void getGradient(MyLine line)
        {
            Console.WriteLine("Gradient of line is: " + line.getGradient());
        }
        static void getZeroDistance(MyPoint point)
        {
            Console.WriteLine(point.distanceWithZero());
        }
    }
}
