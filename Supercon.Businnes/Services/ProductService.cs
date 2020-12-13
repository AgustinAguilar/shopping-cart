using Supercon.DataAccess.Repository;
using Supercon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supercon.Businnes.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public List<string> GetProductCodes()
        {
            var products = _productRepository.GetProducts();
            return products.Select(p => p.ProductCode)
                       .ToList();
        }

        public Product GetProduct(string code)
        {
            var products = _productRepository.GetProducts();
            var result = products.Where(x => x.ProductCode == code).SingleOrDefault();
            return result;
        }
    }
}
