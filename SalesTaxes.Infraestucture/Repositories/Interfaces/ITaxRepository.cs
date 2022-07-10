using SalesTaxes.Domain.Taxes;

namespace SalesTaxes.Infraestructure.Repositories.Interfaces
{
    public interface ITaxRepository
    {
        ICollection<Tax> GetAllTaxes();
    }
}
