using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;

namespace Tavisca.Neighbourhood.Coordinates.Test
{
    [TestClass]
    public class ExcelFileReaderTest
    {
        private ILogger _logger;
        private string _excelFilePath;
        public ExcelFileReaderTest()
        {
            _logger = new TextFileLog("C:/Users/dtripathi/Desktop/ExceptionLogFile.txt");
            _excelFilePath = "C:/Users/dtripathi/Desktop/Neighbour.xlsx";
        }
        [TestMethod]
        public void ImportingNeighbourhoodDataFromFile_ExcludingEntryWithSingleRegionName_CountOfEntryWithMultipleRegionName()
        {
            IFileReader excelFileReader = new ExcelFileReader(_excelFilePath, _logger);
            var neighbourhoodData = excelFileReader.GetNeighbourhoodData();
            Assert.AreEqual(6331, neighbourhoodData.Count);
        }
    }
}
