using System.Collections.Generic;
using Tavisca.Neighbourhood.Coordinates.Model;
namespace Tavisca.Neighbourhood.Coordinates.Contracts
{
    public interface IFileReader
    {
        List<NeighbourhoodCoordinates> GetNeighbourhoodData();
        List<NeighbourhoodCoordinates> ImportingNeighbourhoodDataFromFile();
    }
}
