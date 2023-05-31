using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6Challenge1
{
    internal class MyPoint
    {
        public int x;
        public int y;

        public MyPoint()
        {
            x = 0;
            y = 0;
        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double distanceWithCoords(int x2, int y2)
        {
            double result = 0;
            result = Math.Sqrt(Math.Pow(x2-x, 2) + Math.Pow(y2-y, 2));
            return result;
        }
        public double distanceWithPoint(MyPoint otherPoint)
        {
            double result = 0;
            result = Math.Sqrt(Math.Pow(otherPoint.x - x, 2) + Math.Pow(otherPoint.y - y, 2));
            return result;
        }
        public double distanceWithZero()
        {
            double result = 0;
            result = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return result;
        }
    }
}
