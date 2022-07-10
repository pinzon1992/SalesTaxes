using SalesTaxes.Application.Taxes.Dto;

namespace SalesTaxes.Application.Products.Dtos
{
    public class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<TaxDto> TaxesApplied { get; set; }
    }
}
