using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DL
    {
        public static List<Person> lists = new List<Person>();
        public static void add(Person person)
        {
            lists.Add(person);
        }
    }
}
