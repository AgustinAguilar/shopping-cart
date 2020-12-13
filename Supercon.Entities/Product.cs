using System;
using System.Collections.Generic;
using System.Text;

namespace Supercon.Entities
{
    public class Product
    {
        public double Price { get; }
        public string ProductCode { get; }
        public string Name { get; }

        public Product(double price, string productCode, string name)
        {
            this.Price = price;
            this.ProductCode = productCode;
            this.Name = name;
        }
    }
}
