using System;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;
using Tavisca.Neighbourhood.Coordinates.DB;
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
            var logFilePath = System.Configuration.ConfigurationSettings.AppSettings.Get("exceptionLoggingFileLocation");
            ILogger log = new TextFileLog(logFilePath);
            ExcelFileReader excelFileReader = new ExcelFileReader(@filePath, log);
            //foreach (var neighbourhood in excelFileReader.GetNeighbourhoodData())
            //{
            //    r = neighbourhood.RegionID;
            //    a = neighbourhood.Latitude;
            //    b = neighbourhood.Longitude;
            //    Console.WriteLine("{0},{1},{2}", r, a, b);
            //}
            IDataBase dataBase = new SqlDataBase();
            dataBase.InsertionInTable(excelFileReader.GetNeighbourhoodData());
            Console.ReadKey();
           
        }
    }
}
