using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task practice: Use contructor for name attribute of class");
            Taskpre1();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Task practice: Foreach loop to display list");
            Taskpre2();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Task 1: Clock");
            Task1();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Challenge 1: Clocks");
           Challenge1();
            Console.ReadKey();
            Console.Clear();
        }

        static void Taskpre1()
        {
            string name;
            Console.WriteLine("Enter your name");
            name = Console.ReadLine();
            StudentPracticeTask stu = new StudentPracticeTask(name);
            Console.WriteLine("Your name is: {0}", stu.name);
        }
        static void Taskpre2()
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }
        static void Task1()
        {
            Clock emptyClock = new Clock();
            Console.WriteLine("Empty time: ");
            emptyClock.printTime();

            Clock hourClock = new Clock(2);
            Console.WriteLine("Hour time: ");
            hourClock.printTime();

            Clock minuteClock = new Clock(2, 40);
            Console.WriteLine("minute time: ");
            minuteClock.printTime();

            Clock secondsClock = new Clock(2, 40,20);
            Console.WriteLine("second time: ");
            secondsClock.printTime();

            secondsClock.incrementSeconds();
            secondsClock.printTime();

            secondsClock.incrementMinutes();
            secondsClock.printTime();

            secondsClock.incrementHours();
            secondsClock.printTime();
        }
        static void Challenge1()
        {
            ChallengeClock clock1 = new ChallengeClock(2, 3, 4);
            ChallengeClock clock2 = new ChallengeClock(3, 4, 5);

            clock1.elapsedTime();
            clock1.remainingTime();
            clock1.printTime();
            clock1.clocksDifferent(clock2);
        }
    }
}
