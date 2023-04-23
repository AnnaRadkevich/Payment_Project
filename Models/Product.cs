using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models
{
    internal class Product
    {
        private string _productName;
        private decimal _productPrice;

        public string ProductName { get; }
        public decimal ProductPrice { get; }

        public Product(string productName, decimal productPrice)
        {
            ProductName = productName;
            ProductPrice = productPrice;
        }
        public override string ToString()
        {
            return $"Priduct {ProductName} - {ProductPrice}";
        }
    }
}
