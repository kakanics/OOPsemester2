using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class FireTruckDL
    {
        public static List<FireTruck> trucks = new List<FireTruck>();
        public static List<HosePipe> pipes = new List<HosePipe>();
        public static List<FireFighter> fighters = new List<FireFighter>();

        public static void addTruck(FireTruck truck)
        {
            trucks.Add(truck);
        }
        public static void addFighter(FireFighter fighter)
        {
            fighters.Add(fighter);
        }
        public static void addPipe(HosePipe pipe)
        {
            pipes.Add(pipe);
        }
        public void removeTruck(int index)
        {
            trucks.RemoveAt(index);
        }
        public FireFighter findFireFighterFromName(string name)
        {
            foreach (FireFighter f in fighters)
            {
                if (f.name == name)
                    return f;
            }
            return null;
        }
        public HosePipe findPipeFromID(string id)
        {
            foreach (HosePipe pipe in pipes)
            {
                if (pipe.id == id)
                    return pipe;
            }
            return null;
        }
    }
}
