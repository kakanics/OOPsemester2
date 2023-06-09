using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UL
    {
        public static Student getStudent()
        {
            Console.WriteLine("Enter name");
            string name =Console.ReadLine();
            Console.WriteLine("Enter address");
            string address =Console.ReadLine();
            Console.WriteLine("Enter program");
            string program =Console.ReadLine();
            Console.WriteLine("Enter year");
            int year=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fee");
            double fee =double.Parse(Console.ReadLine());
            return new Student(program, year, fee, name, address);
        }
        public static Person getPerson()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address");
            string address = Console.ReadLine();
            return new Person(name, address);
        }
        public static Staff getStaff()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter school");
            string school = Console.ReadLine();
            Console.WriteLine("Enter pay");
            double pay= double.Parse(Console.ReadLine());
            return new Staff(school, pay, name, address);
        }
        public static void showAll()
        {
            foreach(Person i in DL.lists)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
