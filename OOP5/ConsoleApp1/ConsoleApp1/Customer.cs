using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Customer
    {
        public string Name;
        public string address;
        public string contactNumber;
        public List<Product> boughtProducts = new List<Product>();

        public Customer(string  name, string address, string contactNumber, List<Product> products)
        {
            Name = name;
            this.address = address;
            this.contactNumber = contactNumber;
            this.boughtProducts = products;
        }
        public List<Product> getListOfProducts()
        {
            return boughtProducts;
        }
        public void addProduct(Product product)
        {
            boughtProducts.Add(product);
        }
        public float CalculateTotalTax()
        {
            float totalTax = 0;
            foreach(Product product in boughtProducts)
            {
                totalTax += product.CalculateTax();
            }
            return totalTax;
        }
        public int getTotalPrice()
        {
            int totalPrice = 0;
            foreach(Product product in boughtProducts )
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
