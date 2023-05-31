using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class FireTruck
    {
        public Ladder ladder;
        public string nameOfDriver;
        public string idOfPipe;
        public FireTruck(Ladder ladder, string nameOfDriver, string idOfPipe)
        {
            this.ladder = ladder;
            this.nameOfDriver = nameOfDriver;
            this.idOfPipe = idOfPipe;
        }
    }
}
