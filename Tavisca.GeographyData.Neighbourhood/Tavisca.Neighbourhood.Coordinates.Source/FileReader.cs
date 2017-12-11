using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class FileReader
    {
        private string _filePath;
        private string _coordinates;
        private Excel.Application _xlApp;
        private Excel.Range _xlRange;
        private Excel.Workbook _xlWorkbook;
        private Excel._Worksheet _xlWorksheet;

        public FileReader(string filePath)
        {
            this._filePath = filePath;
        }
        public List<Neighbourhood> GetNeighbourhoodDatafromExcel()
        {
            try
            {
                _xlApp = new Excel.Application();
                _xlWorkbook = _xlApp.Workbooks.Open(_filePath);
                _xlWorksheet = _xlWorkbook.Sheets[1];
                _xlRange = _xlWorksheet.UsedRange;
                return ImportingNeighbourhoodDatafromExcel();
            }
            catch 
            {
                throw new Exception("File Not Found Exception");
            }
            finally
            {
                _xlApp.Quit();
                if (_xlApp != null)
                Marshal.ReleaseComObject(_xlApp);
                _xlApp = null;
                GC.Collect();
            }
           
        }

        public List<Neighbourhood> ImportingNeighbourhoodDatafromExcel()
        {
            List<Neighbourhood> neighbourhoods = new List<Neighbourhood>();
            for (int i = 2; i <= 6 /*_xlRange.Rows.Count*/; i++)
            {
                var regionId = Convert.ToString((_xlRange.Cells[i, 1] as Excel.Range).Value2);
                var regionName = Convert.ToString((_xlRange.Cells[i, 2] as Excel.Range).Value2);
                _coordinates = Convert.ToString((_xlRange.Cells[i, 3] as Excel.Range).Value2);
                GeoCode.GetCoordinates(_coordinates);
                neighbourhoods.Add(new Neighbourhood
                {
                    RegionID = regionId,
                    RegionName = regionName,
                    Latitude = GeoCode.Latitude,
                    Longitude = GeoCode.Longitude

                });
            }
            return neighbourhoods;
        }
    }
}
