using System;
using backend.Constants;

namespace backend.Models
{
    public class GeoCoordinate
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(GeoCoordinate));
        public double Lat { get; set; }
        public double Lng { get; set; }

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
    }
}
