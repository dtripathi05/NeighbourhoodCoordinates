using System;

namespace Tavisca.Neighbourhood.Coordinates.Model
{
    public class WrongFilePathException:Exception
    {
        public WrongFilePathException(string message):base(message)
        {
        }
    }
}
