using System;
using System.Collections.Generic;
using System.IO;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Model;

namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class TextFileReader:IFileReader
    {
        private string _filePath;
        private ILogger _logger;
        private List<string> _geographicNeighbourhoodData;
        private List<NeighbourhoodCoordinates> _neighbourhoodGoegraphicData;
        public TextFileReader(string textFilePath, ILogger log)
        {
            _filePath = textFilePath;
            _logger = log;
            _geographicNeighbourhoodData = new List<string>();
            _neighbourhoodGoegraphicData = new List<NeighbourhoodCoordinates>();
        }
        public void ImportingNeighbourhoodDataFromFile()
        {
            try
            {
                using (var streamReader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        _geographicNeighbourhoodData.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.ExceptionLogging(ex);
            }
        }
        public List<NeighbourhoodCoordinates> GetNeighbourhoodData()
        {

            try
            {
                ImportingNeighbourhoodDataFromFile();
                string[] splittedGeoNeighbourhoodData;
                foreach (var geoNeighbourhood in _geographicNeighbourhoodData)
                {
                    if (geoNeighbourhood.StartsWith("RegionID")||(!geoNeighbourhood.Contains(",")))   
                    {                         
                        continue;   
                    }
                    splittedGeoNeighbourhoodData = SplitGeographicData.GetGeoGraphicData(geoNeighbourhood);
                    GeoCode.GetCoordinates(splittedGeoNeighbourhoodData[2],_logger);
                    RegionNameResolver.GetResolvedRegionName(splittedGeoNeighbourhoodData[1],_logger);
                    _neighbourhoodGoegraphicData.Add(new NeighbourhoodCoordinates
                    {
                        RegionID = splittedGeoNeighbourhoodData[0],
                        RegionName = RegionNameResolver.RegionName.Replace("'", "''"),
                        Latitude = GeoCode.Latitude,
                        Longitude = GeoCode.Longitude,
                        CityName = RegionNameResolver.CityName.Replace("'","''")
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.ExceptionLogging(ex);
            }
            return _neighbourhoodGoegraphicData;
        }
    }
}