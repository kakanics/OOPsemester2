using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class FireFighter : Employee
    {
        public void Drive() { }
        public void Extinguish() { }
        public FireFighter(string name) : base(name) { }
    }
}
