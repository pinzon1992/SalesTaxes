using SalesTaxes.Infraestructure.DataAccess.Interfaces;

namespace SalesTaxes.Infraestructure.DataAccess
{
    public class FileReader : IFileReader
    {
        private readonly string _productFilePath;
        private readonly string _productTypesFilePath;
        public FileReader(string productFilePath, string productTypesFilePath)
        {
            _productFilePath = productFilePath;
            _productTypesFilePath = productTypesFilePath;
        }

        public string ReadAllProductText()
        {
            try
            {
                return File.ReadAllText(_productFilePath);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public string ReadAllProductTypesText()
        {
            try
            {
                return File.ReadAllText(_productTypesFilePath);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
