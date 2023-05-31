using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruckTask
{
    internal class HosePipe
    {
        public string material;
        public string shape;
        public int diameter;
        public int flowrate;
        public string id;
        public HosePipe(string material, string shape, int diameter, int flowrate)
        {
            this.material = material;
            this.shape = shape;
            this.diameter = diameter;
            this.flowrate = flowrate;
        }
    }
}
