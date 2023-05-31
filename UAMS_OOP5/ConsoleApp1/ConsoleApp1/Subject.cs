using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Subject
    {
        public string subjectCode;
        public int creditHours;
        public string subjectType;
        public int price;

        public Subject(string subjectCode, int creditHours, string subjectType, int price)
        {
            this.subjectCode = subjectCode;
            this.creditHours = creditHours;
            this.subjectType = subjectType;
            this.price = price;
        }
    }
}
