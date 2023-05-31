using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
        public string Name;
        public string Category;
        public int Price;
        public Product(string _name, string _Category, int _Price) 
        {
            Name = _name;
            Category = _Category;
            Price = _Price;
        }
        public float CalculateTax()
        {
            return Price * 0.01f;
        }
    }
}
