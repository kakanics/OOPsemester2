using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5LineTask
{
    internal class MyPoint
    {
        int x;
        int y;
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
        public double distanceWithCoords(int x1, int y1)
        {
            double distance = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
            return distance;
        }
        public double distanceWithObject(MyPoint otherPoint)
        {
            double distance = Math.Sqrt(Math.Pow(otherPoint.getX() - x, 2) + Math.Pow(otherPoint.getY() - y, 2));
            return distance;
        }
        public double distanceWithZero()
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }

    }
}
