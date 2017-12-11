namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class GeoCode
    {
        public static string Latitude { get; private set; }
        public static string Longitude { get; private set; }

        public static void GetCoordinates(string coordinates)
        {
            var coordinate = coordinates.Remove(coordinates.IndexOf(':'));
            string[] geoCode = coordinate.Split(";".ToCharArray());
            Latitude = geoCode[0];
            Longitude = geoCode[1];
        }
    }
}