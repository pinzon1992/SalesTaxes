using SalesTaxes.Domain.Products;
using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Products;

namespace SalesTaxes.Tests
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void GetAllProductsTest()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string filePath = directory + @"\" + "input1.txt";
            IFileReader fileReader = new FileReader(filePath, "");
            IProductRepository productRepository = new ProductRepository(fileReader);

            //Act
            var products = productRepository.GetAllProducts();

            //Assert
            Assert.IsType<List<Product>>(products);
        }
    }
}