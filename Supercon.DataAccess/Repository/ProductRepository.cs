using Supercon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supercon.DataAccess.Repository
{
    public class ProductRepository
    {
        // Simple source of products: would come from a database in the real world.
        private List<Product> AllProducts = new List<Product>
        {
            new Product(24.99, "DIS_20-CHAIR_RED", "Red plastic chair"),
            new Product(24.99, "DIS_20-CHAIR_BLUE", "Blue plastic chair"),
            new Product(24.99, "DIS_20-CHAIR_WHITE", "White plastic chair"),
            new Product(14.99, "STOOL_WHITE", "White plastic footstool"),
            new Product(14.99, "DIS_15-STOOL_GREEN", "Green plastic footstool"),
            new Product(74.99, "COMP_DESK", "Wooden computer desk"),
            new Product(129.99, "COMP_CHAIR", "Computer swivel chair"),
            new Product(249.99, "BOARD_TABLE", "12-person boardroom table"),
            new Product(99.99, "BOARD_CHAIR", "Boardroom chair")
        };

        public List<Product> GetProducts()
        {
            return AllProducts;
        }
    }
}
