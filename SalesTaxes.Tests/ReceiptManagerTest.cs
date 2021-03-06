using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Main;

namespace SalesTaxes.Tests
{
    public class ReceiptManagerTest
    {
        [Fact]
        public void GetReceiptTestInput1()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string productFilePath = directory + @"\" + "input1.txt";
            string productTypeFilePath = directory + @"\" + "product_types.json";

            string[] args = { productFilePath, productTypeFilePath };
            var host = CreateBuilder.CreateHostBuilder(args).Build();

            //Act
            var products = host.Services.GetService<IProductService>().GetTaxedProducts();
            ReceiptManager r = new ReceiptManager();
            var result = r.GetReceipt(products);

            //Assert
            string expected_string =
@"Book: 24.98 (2 @ 12.49)
Music CD: 16.49
Chocolate bar: 0.85
Sales Taxes: 1.50
Total: 42.32";
            Assert.Equal(expected_string, result);
        }

        [Fact]
        public void GetReceiptTestInput2()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string productFilePath = directory + @"\" + "input2.txt";
            string productTypeFilePath = directory + @"\" + "product_types.json";

            string[] args = { productFilePath, productTypeFilePath };
            var host = CreateBuilder.CreateHostBuilder(args).Build();

            //Act
            var products = host.Services.GetService<IProductService>().GetTaxedProducts();
            ReceiptManager r = new ReceiptManager();
            var result = r.GetReceipt(products);

            //Assert
            string expected_string =
@"Imported box of chocolates: 10.50
Imported bottle of perfume: 54.65
Sales Taxes: 7.65
Total: 65.15";
            Assert.Equal(expected_string, result);
        }

        [Fact]
        public void GetReceiptTestInput3()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string productFilePath = directory + @"\" + "input3.txt";
            string productTypeFilePath = directory + @"\" + "product_types.json";

            string[] args = { productFilePath, productTypeFilePath };
            var host = CreateBuilder.CreateHostBuilder(args).Build();

            //Act
            var products = host.Services.GetService<IProductService>().GetTaxedProducts();
            ReceiptManager r = new ReceiptManager();
            var result = r.GetReceipt(products);

            //Assert
            string expected_string =
@"Imported bottle of perfume: 32.19
Bottle of perfume: 20.89
Packet of headache pills: 9.75
Imported box of chocolates: 23.70 (2 @ 11.85)
Sales Taxes: 7.30
Total: 86.53";
            Assert.Equal(expected_string, result);
        }
    }
}
