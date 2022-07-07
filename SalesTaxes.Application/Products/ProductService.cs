using SalesTaxes.Application.Products.Dtos;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                TaxApplied = x.TaxApplied
            }).ToList();
        }


    }
}
