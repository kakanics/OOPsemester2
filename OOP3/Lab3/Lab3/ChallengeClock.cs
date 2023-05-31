using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ChallengeClock
    {
        public int hours;
        public int minutes;
        public int seconds;

        public ChallengeClock()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public ChallengeClock(int h)
        {
            hours = h;
        }
        public ChallengeClock(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public ChallengeClock(int h, int m, int s)
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
            if (h == m && m == s)
            {
                return true;
            }
            return false;
        }

        public bool isEqual(ChallengeClock c)
        {
            if (hours == c.hours && minutes == c.minutes && seconds == c.seconds)
            {
                return true;
            }
            return false;
        }

        public void elapsedTime()
        {
            int elapsedSeconds = hours * 3600 + minutes * 60 + seconds;
            Console.WriteLine(elapsedSeconds + " seconds have been elapsed since the start of the day");
        }
        public void remainingTime()
        {
            int elapsedSeconds = hours * 3600 + minutes * 60 + seconds;
            int totalTime = 86400;
            int remainingTime = totalTime - elapsedSeconds;
            Console.WriteLine(remainingTime + " seconds are remaining till the end of the day");
        }
        public void clocksDifferent(ChallengeClock c)
        {
            int ThisElapsedSeconds = hours * 3600 + minutes * 60 + seconds;
            int OtherElapsedSeconds = c.hours * 3600 + c.minutes * 60 + c.seconds;

            if(ThisElapsedSeconds>OtherElapsedSeconds)
            {
                Console.WriteLine("The clocks are away by: {0} seconds", ThisElapsedSeconds - OtherElapsedSeconds);
            }
            else
            {
                Console.WriteLine("The clocks are away by: {0} seconds", OtherElapsedSeconds - ThisElapsedSeconds);
            }
        }
    }
}
