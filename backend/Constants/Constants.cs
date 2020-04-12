namespace backend.Constants
{
    /**
     * Class containing backend constants
     */
    public class Constants
    {
        public const string VERSION = "v1";

        public const double MIN_LATITUDE = 90;
        public const double MAX_LATITUDE = -90;
        public const double MIN_LONGITUDE = 180;
        public const double MAX_LONGITUDE = -180;

        public const int MAX_DISTANCE_METERS = 1400;

        //TODO: moure a variables d'entorn
        public const string LOCATION_IQ_API_KEY = "YOUR_LOCATION_IQ_KEY";
        public const string GOOGLE_MAPS_API_KEY = "YOUR_GOOGLE_MAPS_API_KEY";
        public const string PostgreConnectionString = "YOUR_DATABASE_CONNECTION_STRING";
    }
}
