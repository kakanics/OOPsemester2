using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Circle:Shape
    {
        float radius;
        public Circle(float radius)
        {
            this.radius = radius;
        }
        public void setRadius(float radius)
        {
            this.radius = radius;
        }
        public float getRadius()
        {
            return radius;
        }
        public override double getArea()
        {
            return Math.PI * radius * radius;
        }
        public override string getType() { return "cricle"; }
        public override string ToString() { return "type: " + getType() + ", area: " + getArea(); }

    }
}
