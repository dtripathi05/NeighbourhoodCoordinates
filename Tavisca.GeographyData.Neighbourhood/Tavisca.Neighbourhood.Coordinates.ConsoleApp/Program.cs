using System;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;
using Tavisca.Neighbourhood.Coordinates.DB;
using System.Configuration;
namespace Tavisca.Neighbourhood.Coordinates.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var filePath = ConfigurationSettings.AppSettings.Get("neighbourhoodExcelFileLocation");
            var logFilePath = ConfigurationSettings.AppSettings.Get("exceptionLoggingFileLocation");
            var sqlConnectionString = ConfigurationSettings.AppSettings.Get("sqlConnectionString");
            ILogger log = new TextFileLog(logFilePath);
            ExcelFileReader excelFileReader = new ExcelFileReader(@filePath, log);
            Console.WriteLine("Reading and Importing Data From ExcelFile");
            var geographicDataOfNeighbourhoods = excelFileReader.GetNeighbourhoodData();
            IDataBase dataBase = new SqlDataBase(sqlConnectionString,log);
            Console.WriteLine("Inserting Data InTo The SqlDataBase");
            dataBase.InsertionInTable(geographicDataOfNeighbourhoods);
            Console.WriteLine("Data Inserted In The DB Successfully");
            Console.ReadKey();
           
        }
    }
}
