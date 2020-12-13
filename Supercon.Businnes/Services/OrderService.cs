using Supercon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supercon.Businnes.Services
{
    public class OrderService
    {
        public virtual void ShowConfirmation(Customer customer, IList<Product> products, double totalPrice, int loyaltyPointsEarned)
        {
            //show confirmation
            //do some calculations and formatting on the shopping cart data and ask user for confirmation
            //after confirmation redirect to place order
        }

        public ShoppingCart PlaceOrder(Customer customer, IList<Product> products)
        {
            //place order
            return new Order(customer, products);
        }

    }
}
