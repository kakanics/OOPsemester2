using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Circle
    {
        protected double radius;
        protected string color;
        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }
        public Circle(double radius)
        {
            this.radius=radius;
        }
        public Circle()
        {
            radius = 0;
            color = "red";
        }
        public double GetRadius() { return radius; }
        public string GetColor() { return color; }
        public void SetRadius(double radius)
        {
            this.radius = radius;
        }
        public void setColor(string color)
        {
            this.color=color;
        }
        public double getArea()
        {
            return Math.PI * radius*radius;
        }
        public string toString()
        {
            return "Circle[Radius=" + radius+ ", Color= "+color+"]"; 
        }


    }
}
