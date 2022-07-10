namespace SalesTaxes.Infraestructure.DataAccess.Interfaces
{
    public interface IFileReader
    {
        string ReadAllProductText();

        string ReadAllProductTypesText();
    }
}
