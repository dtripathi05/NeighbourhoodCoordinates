using Tavisca.Neighbourhood.Coordinates.Contracts;
using Tavisca.Neighbourhood.Coordinates.Logger;
using Tavisca.Neighbourhood.Coordinates.Source;
using Tavisca.Neighbourhood.Coordinates.DB;
using Unity;
using Unity.Injection;

namespace Tavisca.Neighbourhood.Coordinates.ConsoleApp
{
    public class DIUnityContainer
    {
        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterType<ILogger, TextFileLog>(new InjectionConstructor(typeof(string)));
            var loggerType = typeof(ILogger);
            container.RegisterType<IDataBase, SqlDataBase>("SqlData",new InjectionConstructor(typeof(string),loggerType));
            container.RegisterType<IFileReader, ExcelFileReader>("ExcelFile",new InjectionConstructor(typeof(string), loggerType));
            container.RegisterType<IFileReader, TextFileReader>("TextFile",new InjectionConstructor(typeof(string), loggerType));
        }
    }
}
