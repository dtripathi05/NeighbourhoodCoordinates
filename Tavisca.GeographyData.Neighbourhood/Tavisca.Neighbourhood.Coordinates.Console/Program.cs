using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Tavisca.Neighbourhood.Coordinates.Source;

namespace Tavisca.Neighbourhood.Coordinates.Console
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            string a;
            string b;
            var filePath = ConfigurationSettings.AppSettings.Get("neighbourhoodExcelFileLocation");
            FileReader excelFileReader = new FileReader(@filePath);
            foreach (var neighbourhood in excelFileReader.GetNeighbourhoodDatafromExcel())
            {
                a = neighbourhood.Latitude;
                b = neighbourhood.Longitude;
            }
            
        }
    }
}
