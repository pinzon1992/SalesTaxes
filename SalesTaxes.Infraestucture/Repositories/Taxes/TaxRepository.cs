using SalesTaxes.Domain.Taxes;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infraestructure.Repositories.Taxes
{
    public class TaxRepository : ITaxRepository
    {
        private readonly List<Tax> taxes;

        public TaxRepository()
        {
            this.taxes = new List<Tax>();
            taxes.Add(new Tax { Id=1, Name= "book", Percentage = 0});
            taxes.Add(new Tax { Id = 1, Name = "chocolate", Percentage = 0 });
            taxes.Add(new Tax { Id = 1, Name = "pills", Percentage = 0 });
            taxes.Add(new Tax { Id = 1, Name = "imported", Percentage = 0.05m});
            taxes.Add(new Tax { Id = 1, Name = "perfume", Percentage = 0.1m});
            taxes.Add(new Tax { Id = 1, Name = "cd", Percentage = 0.1m });
        }

        public ICollection<Tax> GetAllTaxes()
        {
            return taxes;
        }
    }
}
