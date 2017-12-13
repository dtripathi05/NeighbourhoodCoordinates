using System;

namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class GeoCode
    {
        public static decimal Latitude { get; private set; }
        public static decimal Longitude { get; private set; }

        public static void GetCoordinates(string coordinates)
        {
            var coordinate = coordinates.Remove(coordinates.IndexOf(':'));
            string[] geoCode = coordinate.Split(";".ToCharArray());
            Latitude = Convert.ToDecimal(geoCode[0]);
            Longitude = Convert.ToDecimal(geoCode[1]);
        }
    }
}