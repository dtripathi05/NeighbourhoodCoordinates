using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Model;

namespace Tavisca.Neighbourhood.Coordinates.DB
{
    public class SqlDataBase : IDataBase
    {
        private SqlConnection _myConnection;
        private string _sqlConnectionString;
        private ILogger _logger;
        public int Count { get; private set; }
        public SqlDataBase(string sqlConnectionString,ILogger logger)
        {
            this._sqlConnectionString = sqlConnectionString;
            this._logger = logger;
        }
        public void InsertionInTable(List<NeighbourhoodCoordinates> geographicDataNeighbourhood)
        {
            try
            {
                using (_myConnection = new SqlConnection(_sqlConnectionString))
                {
                    Count = 0;
                    _myConnection.Open();
                    foreach (var neighbourhood in geographicDataNeighbourhood)
                    {
                        SqlCommand command = new SqlCommand("spInsertNeighbour", _myConnection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RegionID", neighbourhood.RegionID.Trim());
                        command.Parameters.AddWithValue("@RegionName", neighbourhood.RegionName.Trim());
                        command.Parameters.AddWithValue("@Latitude", neighbourhood.Latitude);
                        command.Parameters.AddWithValue("@Longitude", neighbourhood.Longitude);
                        command.Parameters.AddWithValue("@CityName", neighbourhood.CityName);
                        command.ExecuteNonQuery();
                        Console.WriteLine(Count++ +"/"+neighbourhood.RegionID);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.ExceptionLogging(ex);
            }
        }
    }
}
