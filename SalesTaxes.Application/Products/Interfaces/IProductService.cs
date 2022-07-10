using SalesTaxes.Application.Products.Dtos;

namespace SalesTaxes.Application.Products.Interfaces
{
    public interface IProductService
    {
        ICollection<ProductDto> GetAllProducts();
        ICollection<ProductDto> GetTaxedProducts();
    }
}
