using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Products;
using SalesTaxes.Infraestructure.Repositories.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string FilePath)
        {
            // Repository Dependency Injection
            services.AddSingleton<IFileReader>(new FileReader(FilePath));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITaxRepository, TaxRepository>();

            return services;
        }
    }
}
