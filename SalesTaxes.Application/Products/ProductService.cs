using SalesTaxes.Application.Products.Dtos;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Application.Taxes.Dto;
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
        private readonly ITaxRepository _taxRepository;

        public ProductService(IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _productRepository = productRepository;
            _taxRepository = taxRepository;
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price
            }).ToList();
        }

        public ICollection<ProductDto> GetTaxedProducts()
        {
            var products = _productRepository.GetAllProducts();
            var taxes = _taxRepository.GetAllTaxes();

            foreach (var product in products)
            {
                product.SetTaxApplied(taxes);
            }

            return products.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                TaxesApplied = x.TaxesApplied.Select(y=> new TaxDto { 
                    Id = y.Id,
                    Name = y.Name,
                    Percentage = y.Percentage
                }).ToList()
            }).ToList();
        }
    }
}
