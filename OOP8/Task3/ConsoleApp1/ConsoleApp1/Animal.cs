using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }
        public virtual string ToString()
        {
            return "name: " + name;
        }
    }
}
