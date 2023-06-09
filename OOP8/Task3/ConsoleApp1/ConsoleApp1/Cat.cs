using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cat : Mammal
    {
        public Cat(string name) : base(name) { }
        public override string toString()
        {
            return "cat: " + base.ToString();
        }
        public override void greet()
        {
            Console.WriteLine("meow");
        }
    }
}
