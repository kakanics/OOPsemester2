using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dog:Mammal
    {
        public Dog(string name) : base(name) { }
        public override string toString()
        {
            return "dog: " + base.ToString();
        }
        public override void greet()
        {
            Console.WriteLine("Woof");
        }
        public void greet(Dog dog)
        {
            Console.WriteLine("Woooof");
        }
    }
}
