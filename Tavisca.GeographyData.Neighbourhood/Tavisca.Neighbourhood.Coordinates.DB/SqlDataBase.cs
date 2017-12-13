using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Model;

namespace Tavisca.Neighbourhood.Coordinates.DB
{
    public class SqlDataBase : IDataBase
    {
        private SqlConnection _myConnection;
        private string _sqlConnectionString;
        private ILogger _logger;
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
                    var count = 0;
                    _myConnection.Open();
                    foreach (var neighbourhood in geographicDataNeighbourhood)
                    {
                        SqlCommand sqlInsertCommand = new SqlCommand("Insert into Neighbourhood (RegionID, RegionName, Latitude, Longitude) values( '" + neighbourhood.RegionID.Trim() + "' , '"
                                            + neighbourhood.RegionName.Trim() + "' , " + neighbourhood.Latitude + " , " + neighbourhood.Longitude + ");");
                        sqlInsertCommand.Connection = _myConnection;
                        sqlInsertCommand.ExecuteNonQuery();
                        Console.WriteLine(count++);
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
