using System;
using backend.Models;
using Geolocation;

namespace backend.Utils
{
    /*
     * Location's utils class
     */
    public static class LocationUtils
    {

        /*
         * Calculates the distance in meters between two geolocations
         */
        public static int CalculateDistance(GeoCoordinate from, GeoCoordinate to)
        {

            var origin = new Coordinate { Latitude = from.Lat, Longitude = from.Lng };
            var destination = new Coordinate { Latitude = to.Lat, Longitude = to.Lng };

            return Convert.ToInt32(GeoCalculator.GetDistance(origin, destination, 4, DistanceUnit.Meters));
        }
    }
}
