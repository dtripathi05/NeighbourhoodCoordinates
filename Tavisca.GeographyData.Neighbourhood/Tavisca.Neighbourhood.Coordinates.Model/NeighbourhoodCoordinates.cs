namespace Tavisca.Neighbourhood.Coordinates.Model
{
    public class NeighbourhoodCoordinates
    {
        private string _regionID;
        private string _regionName;
        private string _latitude;
        private string _longitude;

        public string RegionID
        {
            get { return this._regionID; }
            set { this._regionID = value; }
        }
        public string RegionName
        {
            get { return this._regionName; }
            set { this._regionName = value; }
        }
        public string Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }
        public string Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }
    }
}
