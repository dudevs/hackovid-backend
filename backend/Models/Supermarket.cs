namespace backend.Models
{
    /*
     * Supermarket model
     * Contains the needed info to display a list of supermarkets
     */
    public class Supermarket
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public GeoCoordinate location { get; set; }
        public int distance { get; set; }

        public Supermarket()
        {
        }
    }
}
