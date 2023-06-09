using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("billy");
            Cat cat2 = new Cat("lilly");

            Dog dog1 = new Dog("dog1");
            Dog dog2 = new Dog("dog2");
            List<Mammal> animals = new List<Mammal>();
            animals.Add(dog1);
            animals.Add(dog2);
            animals.Add(cat1);
            animals.Add(cat2);

            foreach(var i in animals)
            {
                Console.WriteLine(i.ToString());
                i.greet();
            }
        }
    }
}
