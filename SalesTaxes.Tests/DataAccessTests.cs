using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;

namespace SalesTaxes.Tests
{
    
    public class DataAccessTests
    {
        [Fact]
        public void ReadFileProductTest()
        {
            //Arrange
            string path = Utils.GetPath();
            var directory = Path.GetDirectoryName(path);
            string filePath = directory + @"\" + "input1.txt";
            IFileReader fileReader = new FileReader(filePath, "");

            //Act
            var result = fileReader.ReadAllProductText();

            Console.WriteLine(result);

            //Assert
            Assert.IsType<string>(result);


        }
    }
}
