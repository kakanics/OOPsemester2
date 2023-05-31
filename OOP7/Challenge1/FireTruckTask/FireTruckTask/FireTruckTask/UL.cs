using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class UL
    {
        public static Employee getEmployeeInput()
        {
            Console.WriteLine("enter name of fire fighter");
            string st = Console.ReadLine();
            return new Employee(st);
        }
        public static FireFighter getFireFighterInput()
        {
            Console.WriteLine("enter name of fire fighter");
            string st = Console.ReadLine();
            return new FireFighter(st);
        }
        public static FireChief getFireChiefInput()
        {
            Console.WriteLine("enter name of fire fighter");
            string st = Console.ReadLine();
            return new FireChief(st);
        }
        public static HosePipe getHoseInput()
        {
            Console.WriteLine("enter material of pipe");
            string material = Console.ReadLine();
            Console.WriteLine("enter shape of pipe");
            string shape = Console.ReadLine();
            Console.WriteLine("enter diameter of pipe");
            int diameter = int.Parse(Console.ReadLine());
            Console.WriteLine("enter flowrare of pipe");
            int flowrate = int.Parse(Console.ReadLine());
            Console.WriteLine("enter id of pipe");
            string id = Console.ReadLine();
            return new HosePipe(material, shape, diameter, flowrate);
        }
        public static Ladder getLadderInput()
        {
            Console.WriteLine("Enter length");
            int len = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter color");
            string st = Console.ReadLine();
            return new Ladder(len, st);
        }
        public static FireTruck getFireTruckInput()
        {
            Ladder ladder = getLadderInput();
            Console.WriteLine("Enter name of driver");
            string name = Console.ReadLine();
            Console.WriteLine("Enter id of hosepipe");
            string id = Console.ReadLine();
            return new FireTruck(ladder, name, id);
        }
    }
}
