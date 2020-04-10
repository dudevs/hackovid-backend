using System;
using backend.Models;
using Geolocation;

namespace backend.Utils
{
    public static class DistanceCalculator
    {
        public static int calcualteDistance(GeoCoordinate from, GeoCoordinate to)
        {

            var origin = new Coordinate { Latitude = from.Lat, Longitude = from.Lng };
            var destination = new Coordinate { Latitude = to.Lat, Longitude = to.Lng };

            return Convert.ToInt32(GeoCalculator.GetDistance(origin, destination, 4, DistanceUnit.Meters));
        }
    }
}
