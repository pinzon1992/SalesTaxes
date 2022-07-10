using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Products;
using SalesTaxes.Infraestructure.Repositories.Taxes;

namespace SalesTaxes.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string productFilePath, string productTypesFilePath)
        {
            // Repository Dependency Injection
            services.AddSingleton<IFileReader>(new FileReader(productFilePath, productTypesFilePath));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<ITaxRepository, TaxRepository>();

            return services;
        }
    }
}
