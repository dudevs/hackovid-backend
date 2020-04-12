namespace backend.Models
{
    /**
     * Geocoordinate model
     * Contains the latitude and longitude and allows to check if it is a valid location
     */
    public class GeoCoordinate
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public GeoCoordinate()
        {
            Lat = 0;
            Lng = 0;
        }

        public GeoCoordinate(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public bool IsValid()
        {
            bool isValid = false;

            if ((Constants.Constants.MIN_LATITUDE < Lat) || (Lat < Constants.Constants.MAX_LATITUDE) ||
                (Constants.Constants.MIN_LONGITUDE < Lng) || (Lng < Constants.Constants.MAX_LONGITUDE))
                return isValid;

            return !isValid;
        }

        override
        public string ToString()
        {
            return "Location: lat" + Lat + ", lng:" + Lng;
        }
    }
}
