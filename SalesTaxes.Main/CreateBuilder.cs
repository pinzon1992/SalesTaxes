using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTaxes.Application.Products;
using SalesTaxes.Application.Products.Interfaces;
using SalesTaxes.Application.Taxes;
using SalesTaxes.Application.Taxes.Interfaces;
using SalesTaxes.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Main
{
    public static class CreateBuilder
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string productFilePath = args[0];
            string productTypesFilePath = args[1];
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrastructure(productFilePath, productTypesFilePath);
                    services.AddTransient<IProductService, ProductService>();
                    services.AddTransient<ITaxService, TaxService>();

                });

            return hostBuilder;
        }
    }
}
