using SalesTaxes.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infraestructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
    }
}
