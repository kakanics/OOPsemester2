using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shape
    {
        public virtual double getArea() { return 0; }
        public virtual string getType() { return ""; }
        public virtual string ToString() { return "type: " + getType() + ", area: " + getArea(); }
    }
}
