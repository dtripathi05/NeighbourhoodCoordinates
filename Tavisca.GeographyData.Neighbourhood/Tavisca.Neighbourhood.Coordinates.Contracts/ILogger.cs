using System;
namespace Tavisca.Neighbourhood.Coordinates.Contracts
{
    public interface ILogger
    {
        void ExceptionLogging(Exception ex);
    }
}
