using System;
namespace backend.Models.ApiServices
{
    public class LocationIQ
    {
        public string place_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }

        public LocationIQ()
        {
        }
    }
}
