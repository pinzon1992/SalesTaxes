using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTaxes.Application.Products.Dtos;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Main
{
    public class ReceiptManager
    {

        private decimal TotalSale;
        private decimal TotalTax;
        public ReceiptManager()
        {
            TotalSale = 0;
            TotalTax = 0;
        }

        public string GetReceipt(ICollection<ProductDto> products)
        {
            string result = "";
            List<ProductDetail> productDetailList = new List<ProductDetail>();
            foreach (var product in products)
            {
                var tax_percentage = product.TaxesApplied.Sum(x => x.Percentage);
                var tax = Round.Amount((product.Price * tax_percentage), 0.05M, Round.Type.Up);
                TotalTax += Math.Round(tax, 2);
                var price = (product.Price + tax);
                TotalSale += Math.Round(price, 2);

                if(!productDetailList.Exists(x => x.Name == product.Name))
                {
                    ProductDetail pd = new ProductDetail
                    {
                        Name = product.Name,
                        Quantity = product.Quantity,
                        TotalPriceWithTax = price,
                        UnitaryPriceWithtax = price
                    };
                    productDetailList.Add(pd);
                }
                else
                {
                    var pd = productDetailList.First(x => x.Name == product.Name);
                    pd.Quantity += product.Quantity;
                    pd.TotalPriceWithTax +=price;
                }
            }

            foreach (var productdetail in productDetailList)
            {
                string aux = (productdetail.Quantity > 1) ? $" ({productdetail.Quantity} @ {productdetail.UnitaryPriceWithtax.ToString("0.00")})" : "";
                result += $"{productdetail.Name}: {productdetail.TotalPriceWithTax.ToString("0.00")}{aux}\r\n";
            }
            result += $"Sales Taxes: {TotalTax.ToString("0.00")}\r\n";
            result += $"Total: {TotalSale.ToString("0.00")}";
            return result;
        }
    }

    public class ProductDetail
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPriceWithTax { get; set; }

        public decimal UnitaryPriceWithtax { get; set; }


    }
}
