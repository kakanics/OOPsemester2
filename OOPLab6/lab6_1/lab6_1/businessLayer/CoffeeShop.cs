using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_1.businessLayer
{
    internal class CoffeeShop
    {
        public string name;
        public List<MenuItem> items = new List<MenuItem>();
        public List<string> orders = new List<string>();

        public CoffeeShop(string name) 
        {
            this.name = name;
        }
        
    }
}
