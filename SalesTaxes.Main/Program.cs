// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Application.Products.Interfaces;

using SalesTaxes.Main;

var host = CreateBuilder.CreateHostBuilder(args).Build();
var products = host.Services.GetService<IProductService>().GetTaxedProducts();
ReceiptManager r = new ReceiptManager();

var receipt = r.GetReceipt(products);
Console.WriteLine(receipt);

Console.ReadLine();


