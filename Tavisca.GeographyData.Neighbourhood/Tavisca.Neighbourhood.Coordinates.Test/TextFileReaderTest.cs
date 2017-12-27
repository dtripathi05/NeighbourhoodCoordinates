using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;

namespace Tavisca.Neighbourhood.Coordinates.Test
{
    [TestClass]
    public class TextFileReaderTest
    {
        private ILogger _logger;
        private string _textFilePath;
        public TextFileReaderTest()
        {
            _logger = new TextFileLog("C:/Users/dtripathi/Desktop/ExceptionLogFile.txt");
            _textFilePath = "C:/Users/dtripathi/Desktop/NeighborhoodCoordinatesList.txt";
        }
        [TestMethod]
        public void ImportingNeighbourhoodDataFromFile_ExcludingEntryWithSingleRegionName_CountOfEntryWithMultipleRegionName()
        {
            IFileReader textFileReader = new TextFileReader(_textFilePath, _logger);
            var neighbourhoodData = textFileReader.GetNeighbourhoodData();
            Assert.AreEqual(6331, neighbourhoodData.Count);
        }
    }
}
