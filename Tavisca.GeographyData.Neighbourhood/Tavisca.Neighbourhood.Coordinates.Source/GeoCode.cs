using System;
using Tavisca.Neighbourhood.Coordinates.Contracts;

namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class GeoCode
    {
        public static decimal Latitude { get; private set; }
        public static decimal Longitude { get; private set; }

        public static void GetCoordinates(string coordinates,ILogger logger)
        {
            try
            {
                var coordinate = coordinates.Remove(coordinates.IndexOf(':'));
                string[] geoCode = coordinate.Split(";".ToCharArray());
                Latitude = Convert.ToDecimal(geoCode[0]);
                Longitude = Convert.ToDecimal(geoCode[1]);
            }
            catch (Exception ex)
            {
                logger.ExceptionLogging(ex);
            }
        }
    }
}