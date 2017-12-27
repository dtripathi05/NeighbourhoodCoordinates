using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tavisca.Neighbourhood.Coordinates.DB;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Model;

namespace Tavisca.Neighbourhood.Coordinates.Test
{
    [TestClass]
    public class SqlDataBaseTest
    {
        private SqlDataBase _dataBase;
        private List<NeighbourhoodCoordinates> _geographicData;
        public SqlDataBaseTest()
        {
            var logger = new TextFileLog("C:/Users/dtripathi/Desktop/ExceptionLogFile.txt");
            var sqlConnection = "user id=sa;password=test123!@#;server=localhost;trusted_Connection=yes;database=GeographyDataNeighbourhoodCoordinates";
            _geographicData = new List<NeighbourhoodCoordinates>
                {
                    new NeighbourhoodCoordinates { RegionID = "695", RegionName = "Baoshan, Shanghai",
                        Latitude = Convert.ToInt64(31.49416), Longitude = Convert.ToInt64(121.30734),CityName="China" },
                    new NeighbourhoodCoordinates {RegionID = "696", RegionName = "Hailar, Hulunbuir",
                        Latitude = Convert.ToInt64(49.17200), Longitude = Convert.ToInt64(119.68900) ,CityName="China"},
                };
            _dataBase = new SqlDataBase(sqlConnection, logger);
        }
        [TestMethod]
        public void InsertionInTable_InsertionOfMultipleDataByStoreProcedure_CountOfInsertedData()
        {
            _dataBase.InsertionInTable(_geographicData);
            var insertionCount = _dataBase.Count;
            Assert.AreEqual(2,insertionCount);
        }
    }
}
