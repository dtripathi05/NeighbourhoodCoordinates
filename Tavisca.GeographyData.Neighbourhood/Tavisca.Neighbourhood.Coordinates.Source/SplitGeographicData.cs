namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class SplitGeographicData
    {
        public static string[]  GetGeoGraphicData(string geographicData)
        {
            return  geographicData.Split("|".ToCharArray());
        }
    }
}