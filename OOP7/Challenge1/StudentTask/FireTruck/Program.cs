using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireTruck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DayScholar s1 = new DayScholar(true, "G.T road", 18);
            s1.name = "unk1";
            s1.session = 2022;
            s1.HSMarks = 20;
            s1.ecatMarks = 10;
            Hostellite h1 = new Hostellite(104, false, false);
            h1.name = "unk2";
            h1.session = 2022;
            h1.HSMarks = 20;
            h1.ecatMarks= 30;

            Console.WriteLine(s1.name + " " + s1.busNo);
            Console.WriteLine(h1.name + " "+ h1.roomNumber);
            Console.ReadKey();
        }
    }
}
