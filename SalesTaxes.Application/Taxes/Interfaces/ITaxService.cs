using SalesTaxes.Application.Taxes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Taxes.Interfaces
{
    public interface ITaxService
    {
        ICollection<TaxDto> GetAllTaxes();
    }
}
