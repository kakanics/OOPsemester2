using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.UL
{
    internal class StudentUI
    {
        public static Subject takeInputForSubject()
        {
            string code;
            string type;
            int creditHours;
            int subjectFees;
            Console.WriteLine("Enter code");
            code = Console.ReadLine();
            Console.WriteLine("Enter code");
            type = Console.ReadLine();
            Console.WriteLine("Enter code");
            creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter code");
            subjectFees = int.Parse(Console.ReadLine());
            return new Subject(code, type, creditHours, subjectFees);
        }
        public static void viewSubject(Student s)
        {
            if(s.regDegree!=null)
            {
                Console.WriteLine("Sub Code\tSubType");
                foreach(var i in s.regDegree.subjects) 
                {
                    Console.WriteLine(i.code + "\t\t" + i.type);
                }
            }
        }
        public static void registerSubject(Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register");

        }
    }
}
