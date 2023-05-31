using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Clock
    {
        public int hours;
        public int minutes;
        public int seconds;

        public Clock()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public Clock(int h)
        {
            hours = h;
        }
        public Clock(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public Clock(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementSeconds()
        {
            seconds++;
        }
        public void incrementMinutes()
        {
            minutes++;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void printTime()
        {
            Console.WriteLine("{0}:{1}:{2}", hours, minutes, seconds);
        }

        public bool isEqual(int h, int m, int s)
        {
            if(h==m&&m==s)
            {
                return true;
            }
            return false;
        }

        public bool isEqual(Clock c)
        {
            if(hours == c.hours && minutes == c.minutes && seconds == c.seconds)
            {
                return true;
            }
            return false;
        }
    }
}
