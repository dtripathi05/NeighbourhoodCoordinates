using System;
using Tavisca.Neighbourhood.Coordinates.Contracts;

namespace Tavisca.Neighbourhood.Coordinates.Source
{
    public class RegionNameResolver
    {
        public static string RegionName { get; private set; }
        public static string CityName { get; private set; }
        public static void GetResolvedRegionName(string names,ILogger logger)
        {
            try
            {
                if (names.Contains(","))
                {
                    int index = names.LastIndexOf(',');
                    RegionName = names.Substring(0, index);
                    CityName = names.Substring(index + 1);
                }
                else
                {
                    RegionName = names;
                    CityName = names;
                }
            }
            catch (Exception ex)
            {
                logger.ExceptionLogging(ex);
            }
        }
    }
}