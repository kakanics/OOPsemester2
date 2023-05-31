using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5LineTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLine line = null;
            int choice = 0;
            while(choice != 10)
            {
                Console.Clear();
                menu();
                choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    line = makeALine();
                }
                if (choice == 2)
                {
                    updateBegin(line);
                }
                if (choice == 3)
                {
                    updateEnd(line);
                }
                if (choice == 4)
                {
                    showBegin(line);
                }
                if (choice == 5)
                {
                    showEnd(line);
                }
                if (choice == 6)
                {
                    getLengthOfLine(line);
                }
                if (choice == 7)
                {
                    getgradientOfLine(line);
                }
                if (choice == 8)
                {
                    beginWithOrigin(line);
                }
                if (choice == 9)
                {
                    endWithOrigin(line);
                }
                Console.ReadKey();
            }
        }
        public static void menu()
        {
            Console.WriteLine("1. Make a line\n2. Update begin\n3. Update end\n4. Show Begin\n5. Show end\n6. " +
                "Get length of line\n7. Get gradient\n8. get begin distance with origin\n9. get end distance with origin\n10. Exit");
        }
        public static MyLine makeALine()
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            MyPoint begin = new MyPoint(x1, y1);
            MyPoint end = new MyPoint(x2, y2);

            return new MyLine(begin, end);
        }
        public static void updateBegin(MyLine line)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            MyPoint begin = new MyPoint(x1, y1);
            line.setBegin(begin);
        }
        public static void updateEnd(MyLine line)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            MyPoint end = new MyPoint(x1, y1);
            line.setEnd(end);
        }
        public static void showBegin(MyLine line)
        {
            MyPoint begin = line.getBegin();
            Console.WriteLine(begin.getX() + " " + begin.getY());
        }
        public static void showEnd(MyLine line)
        {
            MyPoint begin = line.getEnd();
            Console.WriteLine(begin.getX() + " " + begin.getY());
        }
        public static void getLengthOfLine(MyLine line)
        {
            Console.WriteLine(line.getLength());
        }
        public static void getgradientOfLine(MyLine line)
        {
            Console.WriteLine(line.getGradient());
        }
        public static void beginWithOrigin(MyLine line)
        {
            Console.WriteLine(line.getBegin().distanceWithZero());
        }
        public static void endWithOrigin(MyLine line)
        {
            Console.WriteLine(line.getEnd().distanceWithZero());
        }
    }
}
