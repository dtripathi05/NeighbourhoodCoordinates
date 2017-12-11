using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Tavisca.Neighbourhood.Coordinates.Source;

namespace Tavisca.Neighbourhood.Coordinates.ConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            string r=null;
            string a=null;
            string b=null;
            var filePath = System.Configuration.ConfigurationSettings.AppSettings.Get("neighbourhoodExcelFileLocation");
            FileReader excelFileReader = new FileReader(@filePath);
            foreach (var neighbourhood in excelFileReader.GetNeighbourhoodDatafromExcel())
            {
                r = neighbourhood.RegionID;
                a = neighbourhood.Latitude;
                b = neighbourhood.Longitude;
                Console.WriteLine("{0},{1},{2}", r, a, b);
            }
            Console.ReadKey();
           
        }
    }
}
