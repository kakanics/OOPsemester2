using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Customer
    {
        public string name;
        public List<Product> products = new List<Product>();
        public List<int> quantity = new List<int>();

        public Customer(string name) 
        {
            this.name = name; 
        }
        public void AddProduct(Product product, int quantity) 
        {
            products.Add(product);
            this.quantity.Add(quantity);
        }
        public float generateInvoice()
        {
            float total = 0;
            for(int i  = 0; i < products.Count; i++)
            {
                total += (products[i].price + products[i].tax()) * quantity[i];
                products[i].quantity -= quantity[i];
            }
            products.Clear();
            quantity.Clear();
            return total;
        }
    }
}
