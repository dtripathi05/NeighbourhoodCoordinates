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
        private Excel.Application _xlApp;
        private Excel.Range _xlRange;
        private ILogger _logger;
        private List<NeighbourhoodCoordinates> _neighbourhoodGoegraphicData;

        public ExcelFileReader(string filePath,ILogger logger)
        {
            this._filePath = filePath;
            this._logger = logger;
            _neighbourhoodGoegraphicData = new List<NeighbourhoodCoordinates>();
            _xlApp = new Excel.Application();
        }
        public List<NeighbourhoodCoordinates> GetNeighbourhoodData()
        {
            try
            {
                Excel.Workbook xlWorkbook = _xlApp.Workbooks.Open(_filePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                _xlRange = xlWorksheet.UsedRange;
                ImportingNeighbourhoodDataFromFile();
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
            return _neighbourhoodGoegraphicData;
        }

        public void  ImportingNeighbourhoodDataFromFile()
        {
            try
            {
                string coordinates;
                for (int i = 2; i <= _xlRange.Rows.Count; i++)
                {
                    coordinates = Convert.ToString((_xlRange.Cells[i, 3] as Excel.Range).Value2);
                    GeoCode.GetCoordinates(coordinates,_logger);
                    RegionNameResolver.GetResolvedRegionName(Convert.ToString((_xlRange.Cells[i, 2] as Excel.Range).Value2), _logger);
                    _neighbourhoodGoegraphicData.Add(new NeighbourhoodCoordinates
                    {
                        RegionID = Convert.ToString((_xlRange.Cells[i, 1] as Excel.Range).Value2),
                        RegionName = RegionNameResolver.RegionName.Replace("'", "''"),
                        CityName=RegionNameResolver.CityName.Replace("'", "''"),
                        Latitude = GeoCode.Latitude,
                        Longitude = GeoCode.Longitude
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.ExceptionLogging(ex);
            }        
        }
    }
}
