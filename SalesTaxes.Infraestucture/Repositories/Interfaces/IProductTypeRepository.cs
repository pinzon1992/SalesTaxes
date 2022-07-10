using SalesTaxes.Domain.Products;

namespace SalesTaxes.Infraestructure.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        ICollection<ProductType> GetAllProductTypes();
    }
}
