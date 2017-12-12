using System;
using System.IO;
using System.Text;
using Tavisca.Neighbourhood.Coordinates.Contracts;
namespace Tavisca.Neighbourhood.Coordinates.Logger
{
    public class TextFileLog : ILogger
    {
        public string LogFilePath { get; private set; }
        public TextFileLog(string logFilePath)
        {
            this.LogFilePath = logFilePath;
        }
        public void ExceptionLogging(Exception ex)
        {
            StringBuilder message = new StringBuilder(string.Format("==>>  Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
            message = message.Append(Environment.NewLine);
            message = message.Append("-----------------------------------**START**-------------------------------------");
            message = message.Append(Environment.NewLine);
            message = message.Append(string.Format("Message: {0}", ex.Message));
            message = message.Append(Environment.NewLine);
            message = message.Append(string.Format("StackTrace: {0}", ex.StackTrace));
            message = message.Append(Environment.NewLine);
            message = message.Append("===================================**END**==============================");
            message = message.Append(Environment.NewLine);
            using (StreamWriter writer = new StreamWriter(LogFilePath,true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
