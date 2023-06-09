using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Rectangle:Shape
    {
        float lenght;
        float width;
        public Rectangle(float lenght, float width)
        {
            this.lenght = lenght;
            this.width = width;
        }
        public void setLength(float lenght)
        {
            this.lenght = lenght;
        }
        public void setWidth(float width)
        {
            this.width = width;
        }
        public float getLength()
        {
            return this.lenght;
        }
        public float getWidth()
        {
            return width;
        }
        public override double getArea()
        {
            return lenght*width;
        }
        public override string getType(){return "rectangle";}
        public override string ToString() { return "type: " + getType() + ", area: " + getArea(); }

    }
}
