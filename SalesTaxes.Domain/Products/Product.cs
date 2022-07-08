using SalesTaxes.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Domain.Products
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public ICollection<Tax> TaxesApplied { get; set; }

        public Product()
        {
            TaxesApplied = new List<Tax>();
        }


        public void SetTaxApplied(ICollection<Tax> taxes)
        {
            TaxesApplied = taxes.Where(x => this.Name.ToLower().Contains(x.Name)).Select(x=> x).ToList(); 

        }

    }
}
