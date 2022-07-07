using SalesTaxes.Infraestructure.DataAccess;
using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Tests
{
    
    public class DataAccessTests
    {
        [Fact]
        public void ReadFileTest()
        {
            //Arrange
            string filePath = @"D:\Documents\source\repos\number8\backend\SalesTaxes\SalesTaxes.Main\input1.txt";
            IFileReader fileReader = new FileReader(filePath);

            //Act
            var result = fileReader.ReadAllText();

            Console.WriteLine(result);

            //Assert
            Assert.IsType<string>(result);


        }
    }
}
