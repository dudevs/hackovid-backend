using System;
using backend.Constants;
using backend.Models.Interfaces;

namespace backend.Models
{
    public class GeoCoordinate : IModel
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

        public ModelErrorCodes GetErrorCode()
        {
            if ((Constants.Constants.MIN_LATITUDE < Lat) || (Lat < Constants.Constants.MAX_LATITUDE))
            {
                //Log.Error(new { Field = "latitude", value = Lat });
                return ModelErrorCodes.Invalid_lat;
            }

            if ((Constants.Constants.MIN_LONGITUDE < Lng) || (Lng < Constants.Constants.MAX_LONGITUDE))
            {
                //Log.Error(new { Field = "longitude", value = Lng });
                return ModelErrorCodes.Invalid_long;
            }

            //Log.Error(new { Field = "Unknown error", value = "" });
            return ModelErrorCodes.Unknown_error;
        }
    }
}
