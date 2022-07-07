using SalesTaxes.Application.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Application.Products.Interfaces
{
    public interface IProductService
    {
        ICollection<ProductDto> GetAllProducts();
    }
}
