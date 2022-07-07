// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTaxes.Application.Products;
using SalesTaxes.Application.Products.Dtos;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Application.Taxes;
using SalesTaxes.Application.Taxes.Dto;
using SalesTaxes.Application.Taxes.Interfaces;
using SalesTaxes.Infraestructure;

var host = CreateHostBuilder(args).Build();
var products = host.Services.GetService<IProductService>().GetAllProducts();
var taxes = host.Services.GetService<ITaxService>().GetAllTaxes();

Console.ReadLine();

static void GetInvoice(ICollection<ProductDto> products, ICollection<TaxDto> taxes)
{
    

    var sb = new System.Text.StringBuilder();
    foreach (var product in products)
    {
        sb.AppendLine(product.Name + ":");
    }

}

static string GetDetailedTotal(ProductDto product, List<TaxDto> taxes)
{
    string detail = "";
    var total = 0.0m;
    var tax_value = 0.0m;
    if (product.Quantity > 1)
    {
        foreach (var tax in taxes)
        {
            if (product.Name.ToLower().Contains(tax.Name))
            {
                tax_value = product.Price * tax.Percentage;
            } 
        }
        
    }
    return "";
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    string filepath = args[0];
    var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
        })
        .ConfigureServices((context, services) =>
        {
            services.AddInfrastructure(filepath);
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITaxService, TaxService>();

        });

    return hostBuilder;
}