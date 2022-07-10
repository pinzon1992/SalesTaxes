using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using SalesTaxes.Infraestructure.Repositories.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SalesTaxes.Infraestructure.Repositories.Products
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IFileReader _fileReader;

        public ProductTypeRepository(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public ICollection<ProductType> GetAllProductTypes()
        {
            List<ProductType> products = new List<ProductType>();
            var data = _fileReader.ReadAllProductTypesText();
            if (!string.IsNullOrEmpty(data))
            {
                // JsonObject parse DOM
                JsonObject jsonObject = JsonNode.Parse(data).AsObject();
                var ex = jsonObject["product_types"].Deserialize<List<ProductType>>();
                return ex;
            }
            else
            {
                throw new Exception("File is empty, data can't be readed");
            }
        }
    }
}
