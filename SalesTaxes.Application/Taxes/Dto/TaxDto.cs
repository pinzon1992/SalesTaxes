using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Taxes.Dto
{
    public class TaxDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Percentage { get; set; }
    }
}
