using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            FireTruckDL.addTruck(UL.getFireTruckInput());
            Console.Clear();
            FireTruckDL.addTruck(UL.getFireTruckInput());
            Console.Clear();
            FireTruckDL.addTruck(UL.getFireTruckInput());
            Console.Clear();
            FireTruckDL.addTruck(UL.getFireTruckInput());

            Console.Clear();
            FireTruckDL.addPipe(UL.getHoseInput());
            Console.Clear();
            FireTruckDL.addPipe(UL.getHoseInput());
            Console.Clear();
            FireTruckDL.addPipe(UL.getHoseInput());
            Console.Clear();
            FireTruckDL.addPipe(UL.getHoseInput());

            Console.Clear();
            FireTruckDL.addFighter(UL.getFireFighterInput());
            Console.Clear();
            FireTruckDL.addFighter(UL.getFireFighterInput());
            Console.Clear();
            FireTruckDL.addFighter(UL.getFireFighterInput());
            Console.Clear();
            FireTruckDL.addFighter(UL.getFireFighterInput());

            Console.WriteLine("made many objects");
            Console.ReadKey();
        }
    }
}
