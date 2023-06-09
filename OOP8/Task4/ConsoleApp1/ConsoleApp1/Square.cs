using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Square:Shape
    {
        float lenght;
        public Square(float lenght)
        {
            this.lenght = lenght;
        }
        public void setLength(float lenght)
        {
            this.lenght = lenght;
        }
        public float getLength()
        {
            return this.lenght;
        }
        public override double getArea()
        {
            return lenght * lenght;
        }
        public override string getType() { return "square"; }
        public override string ToString() { return "type: " + getType() + ", area: " + getArea(); }

    }
}
