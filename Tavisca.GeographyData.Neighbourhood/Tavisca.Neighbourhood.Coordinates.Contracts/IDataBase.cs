using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.Neighbourhood.Coordinates.Model;

namespace Tavisca.Neighbourhood.Coordinates.Contracts
{
    public interface IDataBase
    {
        void InsertionInTable(List<NeighbourhoodCoordinates> coordinates);
    }
}
