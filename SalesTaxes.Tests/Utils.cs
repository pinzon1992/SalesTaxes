using System.Runtime.CompilerServices;

namespace SalesTaxes.Tests
{
    public static class Utils
    {
        public static string GetPath([CallerFilePath] string fileName = null)
        {
            return fileName;
        }
    }
}
