using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Tests
{
    public class ProductTypeRepositoryTest
    {
        [Fact]
        public void GetAllProductTypesTest()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string filePath = directory + @"\" + "product_types.json";
            IFileReader fileReader = new FileReader("", filePath);
            IProductTypeRepository productTypeRepository = new ProductTypeRepository(fileReader);

            //Act
            var products = productTypeRepository.GetAllProductTypes();

            //Assert
            Assert.IsType<bool>(true);
        }
    }
}
