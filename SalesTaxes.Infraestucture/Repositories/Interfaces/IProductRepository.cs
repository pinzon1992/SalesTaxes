using SalesTaxes.Domain.Products;

namespace SalesTaxes.Infraestructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
    }
}
