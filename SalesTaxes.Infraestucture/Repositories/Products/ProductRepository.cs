using SalesTaxes.Domain.Products;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using SalesTaxes.Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infraestructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IFileReader _fileReader;

        public ProductRepository(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public ICollection<Product> GetAllProducts()
        {

            List<Product> products;
            var data = _fileReader.ReadAllText();
            if  (!string.IsNullOrEmpty(data)){
                products = new List<Product>();
                var lines = data.Split("\n");
                int counter = 1;
                foreach (var item in lines)
                {
                    
                    var product_splitted = item.Split(" at ");
                    var product_quantity_name = product_splitted[0].Split(" ");

                    string product_name = DataManipulation.JoinStrArray(product_quantity_name, 0);

                    Product product = new Product
                    {
                        Id = counter,
                        Name = product_name,
                        Quantity = Convert.ToInt32(product_quantity_name[0]),
                        Price = Convert.ToDecimal(product_splitted[1]),
                    };
                    products.Add(product);
                }
            }
            else
            {
                throw new Exception("File is empty, data can't be readed");
            }
            
            return products;
        }
    }
}
