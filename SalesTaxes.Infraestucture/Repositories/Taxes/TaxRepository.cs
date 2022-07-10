using SalesTaxes.Domain.Taxes;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SalesTaxes.Infraestructure.Repositories.Taxes
{
    public class TaxRepository : ITaxRepository
    {
        private readonly IFileReader _fileReader;

        private readonly ICollection<Tax> _taxes;

        public TaxRepository()
        {
            _taxes = new List<Tax>();
            _taxes.Add(new Tax { Id=1, Name= "food", Percentage = 0});
            _taxes.Add(new Tax { Id = 2, Name = "medical", Percentage = 0 });
            _taxes.Add(new Tax { Id = 3, Name = "book", Percentage = 0 });
            _taxes.Add(new Tax { Id = 4, Name = "imported", Percentage = 0.05m});
            _taxes.Add(new Tax { Id = 5, Name = "basic_tax", Percentage = 0.1m });
        }

        public ICollection<Tax> GetAllTaxes()
        {

            return _taxes;
        }
    }
}
