using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class ExcelFileReader:IFileReader
    {
        private string _filePath;
        private string _coordinates;
        private Excel.Application _xlApp;
        private Excel.Range _xlRange;
        private Excel.Workbook _xlWorkbook;
        private Excel._Worksheet _xlWorksheet;
        private ILogger _logger;
        public ExcelFileReader(string filePath,ILogger logger)
        {
            this._filePath = filePath;
            this._logger = logger;
        }
        public List<NeighbourhoodCoordinates> GetNeighbourhoodData()
        {
            List<NeighbourhoodCoordinates> coordinates=new List<NeighbourhoodCoordinates>();
            try
            {
                _xlApp = new Excel.Application();
                _xlWorkbook = _xlApp.Workbooks.Open(_filePath);
                _xlWorksheet = _xlWorkbook.Sheets[1];
                _xlRange = _xlWorksheet.UsedRange;
                coordinates= ImportingNeighbourhoodDataFromFile();
            }
            catch (Exception ex)
            {
                _logger.ExceptionLogging(ex);
            }
            finally
            {
                _xlApp.Quit();
                if (_xlApp != null)
                Marshal.ReleaseComObject(_xlApp);
                _xlApp = null;
                GC.Collect();
            }
            return coordinates;
        }

        public List<NeighbourhoodCoordinates> ImportingNeighbourhoodDataFromFile()
        {
            List<NeighbourhoodCoordinates> neighbourhoods = new List<NeighbourhoodCoordinates>();
            for (int i = 2; i <= _xlRange.Rows.Count; i++)
            {
                _coordinates = Convert.ToString((_xlRange.Cells[i, 3] as Excel.Range).Value2);
                GeoCode.GetCoordinates(_coordinates);
                neighbourhoods.Add(new NeighbourhoodCoordinates
                {
                    RegionID = Convert.ToString((_xlRange.Cells[i, 1] as Excel.Range).Value2),
                    RegionName = Convert.ToString((_xlRange.Cells[i, 2] as Excel.Range).Value2),
                    Latitude = GeoCode.Latitude,
                    Longitude = GeoCode.Longitude
                });
            }
            return neighbourhoods;
        }
    }
}
