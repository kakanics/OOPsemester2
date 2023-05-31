using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Product
    {
        public string name;
        public string category;
        public int price;
        public int quantity;
        public int threshold;

        public Product(string name, string category, int price, int quantity, int threshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.quantity = quantity;
            this.threshold = threshold;
        }
        public float tax()
        {
            if (category == "grocery") return price * 0.1f;
            if (category == "fruit") return price * 0.05f;
            return price * 0.15f;
        }
        public bool buyThis()
        {
            if(threshold>quantity) return true;
            return false;
        }
    }
}
