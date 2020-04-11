namespace backend.Constants
{
    public class Constants
    {
        public const double MIN_LATITUDE = 90;
        public const double MAX_LATITUDE = -90;
        public const double MIN_LONGITUDE = 180;
        public const double MAX_LONGITUDE = -180;

        public const int MAX_DISTANCE_METERS = 1000;

        public const string LOCATION_IQ_API_KEY = "09c9f9f19650d2";
        public const string GOOGLE_MAPS_API_KEY = "AIzaSyDOSNzdaR7KH38DS7SW105Lsmmbfr3WQm4";

        //TODO: this is a guarrada
        public const string PostgreConnectionString = "host=localhost;Database=dudevs;user id=dudevs;Password=dudevs";
    }
}
