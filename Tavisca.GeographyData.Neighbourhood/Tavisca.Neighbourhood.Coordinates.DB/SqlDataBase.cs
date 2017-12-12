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
        public void InsertionInTable(List<NeighbourhoodCoordinates> coordinates)
        {
            using (_myConnection= new SqlConnection("user id=sa;" +
                                         "password=test123!@#;server=localhost;" +
                                         "Trusted_Connection=yes;" +
                                         "database=GeographyDataNeighbourhoodCoordinates; " +
                                         "connection timeout=60"))
            {
                _myConnection.Open();
                foreach(var neighbourhood in coordinates)
                {
                    SqlCommand sqlCommand = new SqlCommand("Insert into NeighbourhoodCoordinates (RegionID, RegionName, Latitude, Longitude) values( '" + neighbourhood.RegionID.Trim() + "' , '"
                                        + neighbourhood.RegionName.Trim() + "' , '" + neighbourhood.Latitude.Trim() + "' , '" + neighbourhood.Longitude.Trim() + "');");
                }
            }
            

        }
    }
}
