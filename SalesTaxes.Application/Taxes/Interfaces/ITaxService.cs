using SalesTaxes.Application.Taxes.Dto;

namespace SalesTaxes.Application.Taxes.Interfaces
{
    public interface ITaxService
    {
        ICollection<TaxDto> GetAllTaxes();
    }
}
