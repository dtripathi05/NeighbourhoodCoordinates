namespace Tavisca.Neighbourhood.Coordinates.Model
{
    public class NeighbourhoodCoordinates
    {
        private string _regionID;
        private string _regionName;
        private decimal _latitude;
        private decimal _longitude;
        private string _cityName;

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
        public decimal Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }
        public decimal Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }
        public string CityName {
            get {return this._cityName; }
            set {this._cityName = value; }
        }
    }
}
