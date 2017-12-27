using System;
using System.Configuration;
using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;
using Unity;
using Unity.Resolution;

namespace Tavisca.Neighbourhood.Coordinates.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var textFilePath = ConfigurationSettings.AppSettings.Get("NeighbourhoodTextFileLocation");
            var filePath = ConfigurationSettings.AppSettings.Get("NeighbourhoodExcelFileLocation");
            var logFilePath = ConfigurationSettings.AppSettings.Get("ExceptionLoggingFileLocation");
            var sqlConnectionString = ConfigurationSettings.AppSettings.Get("SqlConnectionString");
            IUnityContainer container = new UnityContainer();
            DIUnityContainer.RegisterElements(container);
            ILogger textLogger = container.Resolve<ILogger>(new ParameterOverride("logFilePath", logFilePath));
            IFileReader excelFileReader = container.Resolve<IFileReader>("ExcelFile", new ParameterOverride("filePath",filePath), new ParameterOverride("logger", textLogger));
            IFileReader textFileReader = container.Resolve<IFileReader>("TextFile", new ParameterOverride("textFilePath",textFilePath),new ParameterOverride("log", textLogger));
            Console.WriteLine("Reading and Importing Data From ExcelFile");
           // var geographicDataFromExcel = excelFileReader.GetNeighbourhoodData();
            var geographicDataFromTextFile = textFileReader.GetNeighbourhoodData();
            IDataBase sqlDB = container.Resolve<IDataBase>("SqlData",new ParameterOverride("sqlConnectionString", sqlConnectionString), new ParameterOverride("logger", textLogger));
            Console.WriteLine("Inserting Data InTo The SqlDataBase");
            sqlDB.InsertionInTable(geographicDataFromTextFile);
            Console.WriteLine("Data Inserted In The DB Successfully");
            Console.ReadKey();
        }
    }
}
