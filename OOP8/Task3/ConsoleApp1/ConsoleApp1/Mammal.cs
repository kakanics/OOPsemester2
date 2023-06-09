using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Mammal:Animal
    {
        public Mammal(string name) : base(name) { }
        public virtual string toString()
        {
            return "mammal: " + base.ToString();
        }
        public virtual void greet()
        {
            Console.WriteLine("Mammal greets");
        }
    }
}
