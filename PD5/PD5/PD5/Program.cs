using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PD5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> shipList = new List<Ship>();
            char choice = '0';
            while (choice != '5')
            {
                Console.Clear();
                menu();
                choice = Console.ReadLine()[0];
                if(choice == '1')
                {
                    addShipToList(shipList );
                }
                if (choice == '2')
                {
                    viewShipPosition(shipList);
                }
                if (choice == '3')
                {
                    viewShipID(shipList);
                }
                if (choice == '4')
                {
                    changeShipPosition(shipList);
                }
                Console.ReadKey();
            }
        }
        static void menu()
        {
            Console.WriteLine("1. Add Ship\n2. View Ship Position\n3. View Ship serial number\n4. Change Ship position\n5. Exit");
        }
        static void addShipToList(List<Ship> shipList)
        {
            shipList.Add(shipBuilder());
        }
        static Ship shipBuilder()
        {
            string sName;
            int deg1, deg2;
            float min1, min2;
            char dir1, dir2;
            Console.WriteLine("Enter serial number of the ship");
            sName = Console.ReadLine();
            Console.WriteLine("Enter degrees of the ship's latitude");
            deg1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter minutes of the ship's latitude");
            min1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter direction of the ship's latitude");
            dir1 = Console.ReadLine()[0];
            Console.WriteLine("Enter degrees of the ship's longitude");
            deg2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter minutes of the ship's longitude");
            min2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter direction of the ship's longitude");
            dir2 = Console.ReadLine()[0];
            if(deg1>=180||deg1<=0||deg2>=90||deg2<=0)
            {
                Console.Write("invalid degree");
                return null;
            }
            if((dir1=='E'||dir1=='W')&&(dir2=='N'||dir2=='S'))
            {
                Ship temp = new Ship(sName, deg1, min1, dir1, deg2, min2, dir2);
                return temp;
            }
            else
            {
                Console.WriteLine("invalid direction");
            }
            return null;
        }
        static void viewShipPosition(List<Ship> shipList)
        {
            string sName;
            Console.WriteLine("Enter ship ID");
            sName = Console.ReadLine();
            foreach (Ship ship in shipList)
            {
                if (ship.getShipID() == sName)
                {
                    Console.WriteLine(ship.getPosition());
                }
            }
        }
        static void viewShipID(List<Ship> shipList)
        {
            string lati;
            string longi;
            Console.WriteLine("Enter Ship latitude, use < to represent degree and \' to represent minutes, write in format DDD<MMM<C");
            lati = Console.ReadLine();
            string[] latis = lati.Split('<', '\'');
            Console.WriteLine("Enter Ship longitude, use < to represent degree and \' to represent minutes, write in format DDD<MMM<C");
            longi = Console.ReadLine();
            string[] longis = longi.Split('<', '\'');
            foreach (Ship ship in shipList)
            {
                if (ship.latitude.degrees == int.Parse(latis[0]) && ship.longitude.degrees == int.Parse(longis[0])
                    && ship.latitude.minutes == float.Parse(latis[1])&& ship.longitude.minutes == float.Parse(longis[1])
                    && ship.latitude.direction == latis[2][0] && ship.latitude.direction == longis[2][0])
                {
                    Console.WriteLine("The ship is {0}", ship.getShipID());
                }
            }
        }
        static void changeShipPosition(List<Ship> shipList)
        {
            string sName;
            Console.WriteLine("Enter ship id");
            sName = Console.ReadLine();
            foreach(Ship ship in shipList)
            {
                if(ship.getShipID() == sName)
                {
                    int deg1, deg2;
                    float min1, min2;
                    char dir1, dir2;
                    Console.WriteLine("Enter degrees of the ship's latitude");
                    deg1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter minutes of the ship's latitude");
                    min1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter direction of the ship's latitude");
                    dir1 = Console.ReadLine()[0];
                    Console.WriteLine("Enter degrees of the ship's longitude");
                    deg2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter minutes of the ship's longitude");
                    min2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter direction of the ship's longitude");
                    dir2 = Console.ReadLine()[0];
                    Angle newLati = new Angle(deg1, min1, dir1);
                    Angle newLongi = new Angle(deg2, min2, dir2);
                    ship.latitude = newLati;
                    ship.longitude = newLongi;
                }
            }
        }
    }
}
