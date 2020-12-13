using System;
using System.Collections.Generic;
using System.Text;

namespace Supercon.Entities
{
    public class ShoppingCart
    {
        //Product and quantity
        private IList<Product> products;
        private Customer customer;
        private string cartState;

        public ShoppingCart(Customer customer, IList<Product> products, string cartState)
        {
            this.customer = customer;
            this.products = products;
            this.cartState = cartState;
        }
    }
}
