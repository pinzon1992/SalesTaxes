using SalesTaxes.Domain.Taxes;

namespace SalesTaxes.Domain.Products
{
    public class Product
    {
        public Product()
        {
            TaxesApplied = new List<Tax>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsImported { get { return Name.ToLower().Contains("imported"); } }

        public ProductType? ProductType { get; set; }

        public ICollection<Tax> TaxesApplied { get; set; }

        public void SetTaxApplied(ICollection<Tax> taxes)
        {
            if(ProductType is null || ProductType.Name == "other")
            {
                var tax = taxes.First(x => x.Name == "basic_tax");
                TaxesApplied.Add(tax);
            }
            else
            {
                var tax = taxes.First(x => x.Name == ProductType.Name);
                TaxesApplied.Add(tax);
            }

            if (IsImported)
            {
                var tax = taxes.First(x => x.Name == "imported");
                TaxesApplied.Add(tax);
            }
        }

    }
}
