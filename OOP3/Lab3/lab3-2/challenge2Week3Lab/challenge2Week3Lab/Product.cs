using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge2Week3Lab
{
    internal class Product
    {
        public string name;
        public string category;
        public int price;
        public int quantity;
        public int minQuantity;

        public Product(string _name)
        {
            name = _name;
        }

        public Product(string _name, string _category)
        {
            name = _name;
            category = _category;
        }

        public Product(string _name, string _category, int _price)
        {
            name = _name;
            category = _category;
            price = _price;
        }

        public Product(string _name, string _category, int _price, int _quantity)
        {
            name = _name;
            category = _category;
            price = _price;
            quantity = _quantity;
        }

        public Product(string _name, string _category, int _price, int _quantity, int _minQt)
        {
            name = _name;
            category = _category;
            price = _price;
            quantity = _quantity;
            minQuantity = _minQt;
        }
        public Product(Product copyObject)
        {
            name = copyObject.name;
            category = copyObject.category;
            price = copyObject.price;
            quantity = copyObject.quantity;
            minQuantity = copyObject.minQuantity;
        }
    }
}
