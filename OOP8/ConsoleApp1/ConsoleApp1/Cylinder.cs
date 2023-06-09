using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cylinder:Circle
    {
        private double height;
        public Cylinder(double height)
        {
            this.height = height;
        }
        public Cylinder()
        {
            height = 0;
        }
        public Cylinder(double height, double radius) : base(radius)
        {
            this.height = height;
        }
        public Cylinder(double height, double radius, string color): base(radius,color)
        {
            this.height=height;
        }
        public double getHeight()
        {
            return height;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }
        public double getVolume()
        {
            return height * GetRadius();
        }
    }
}
