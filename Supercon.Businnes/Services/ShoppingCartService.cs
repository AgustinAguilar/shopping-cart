using Supercon.DataAccess.Repository;
using Supercon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supercon.Businnes.Services
{
    public class ShoppingCartService
    {
        private readonly ProductRepository _productRepository;
        private readonly OrderService _orderService;

        public ShoppingCartService(ProductRepository productRepository, OrderService orderService)
        {
            this._productRepository = productRepository;
            this._orderService = orderService;
        }

        public void AddProduct(Product product)
        {
            var products = this._productRepository.GetProducts();
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            var products = this._productRepository.GetProducts();
            products.Remove(product);
        }

        /*
            Checkout: Calculates total price and total loyalty points earned by the customer.
            Products with product code starting with DIS_10 have a 10% discount applied.
            Products with product code starting with DIS_15 have a 15% discount applied.

            Loyalty points are earned more when the product is not under any offer.
                Customer earns 1 point on every $5 purchase.
                Customer earns 1 point on every $10 spent on a product with 10% discount.
                Customer earns 1 point on every $15 spent on a product with 15% discount.
        */
        public void Checkout(IList<Product> products, Customer customer)
        {
            double totalPrice = 0;

            int loyaltyPointsEarned = 0;
            foreach (Product product in products)
            {
                double discount = 0;
                if (product.ProductCode.StartsWith("DIS_20", System.StringComparison.OrdinalIgnoreCase))
                {
                    discount = (product.Price * 0.2);
                    loyaltyPointsEarned += (int)(product.Price / 20);
                }
                else if (product.ProductCode.StartsWith("DIS_15", System.StringComparison.OrdinalIgnoreCase))
                {
                    discount = (product.Price * 0.15);
                    loyaltyPointsEarned += (int)(product.Price / 15);
                }
                else if (product.ProductCode.StartsWith("DIS_PKG", System.StringComparison.OrdinalIgnoreCase) 
                                                && products.Where(x => x.ProductCode.StartsWith("DIS_PKG", System.StringComparison.OrdinalIgnoreCase)).Count() > 2)
                {
                    discount = (product.Price * 0.2);
                }
                else
                {
                    loyaltyPointsEarned += (int)(product.Price / 5);
                }

                totalPrice += product.Price - discount;
            }

            if (totalPrice > 1000)
            {
                var discount = (totalPrice * 0.1);
                totalPrice = totalPrice - discount;
            }



            _orderService.ShowConfirmation(customer, products, totalPrice, loyaltyPointsEarned);
        }


    }
}
