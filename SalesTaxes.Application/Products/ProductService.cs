using SalesTaxes.Application.Products.Dtos;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Application.Taxes.Dto;
using SalesTaxes.Domain.Products;
using SalesTaxes.Domain.Taxes;
using SalesTaxes.Infraestructure.Repositories.Interfaces;

namespace SalesTaxes.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductService(IProductRepository productRepository, ITaxRepository taxRepository, IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _taxRepository = taxRepository;
            _productTypeRepository = productTypeRepository;
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
            ICollection<Product> products = _productRepository.GetAllProducts();
            ICollection<Tax> taxes = _taxRepository.GetAllTaxes();

            products = SetProductType(products);

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

        private ICollection<Product> SetProductType(ICollection<Product> products)
        {
            ICollection<ProductType> productTypes = _productTypeRepository.GetAllProductTypes();

            foreach (var product in products)
            {
                product.ProductType = productTypes.FirstOrDefault(x => x.AssociatedProductNames.Any(y => y == product.Name));
            }

            return products;
        }
    }
}
