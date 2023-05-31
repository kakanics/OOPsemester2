using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6Challenge1
{
    internal class MyLine
    {
        MyPoint begin;
        MyPoint end;

        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;
        }
        public MyPoint getBegin()
        {
            return begin;
        }
        public MyPoint getEnd()
        {
            return end;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }
        public void setEnd(MyPoint end)
        {
            this.end = end;
        }
        public double getLength()
        {
            return end.distanceWithPoint(begin);
        }
        public double getGradient() 
        {
            return (end.y - begin.y)/(end.x-begin.x);
        }
    }
}
