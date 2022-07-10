using SalesTaxes.Application.Taxes.Dto;
using SalesTaxes.Application.Taxes.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;

namespace SalesTaxes.Application.Taxes
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;
        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public ICollection<TaxDto> GetAllTaxes()
        {
            var taxes =  _taxRepository.GetAllTaxes();
            return taxes.Select(x => new TaxDto { 
                Id = x.Id,
                Name = x.Name,
                Percentage = x.Percentage
            }).ToList();
        }
    }
}
