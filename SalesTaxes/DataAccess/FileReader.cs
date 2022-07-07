using SalesTaxes.Infraestructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.Infraestructure.DataAccess
{
    public class FileReader : IFileReader
    {
        private readonly string _filePath;
        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadAllText()
        {
            return File.ReadAllText(_filePath);
        }
    }
}
