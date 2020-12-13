using System;
using System.Collections.Generic;
using System.Text;

namespace Supercon.Entities
{
    public class Order: ShoppingCart
    {
        public Order(Customer customer, IList<Product> products) : base(customer, products, "ORDER_PLACED")
        {
        }
    }
}
