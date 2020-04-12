using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Models.ApiServices;

namespace backend.Providers.ApiServices
{
    /**
     * Location IQ service class
     * Manages all the requests to Location IQ api's
     */
    public class LocationIQApiService
    {
        public HttpClient Client { get; }

        public LocationIQApiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://eu1.locationiq.com/v1/");

            Client = client;
        }

        /**
         * Gets the latitude and longitude given an address
         */
        public async Task<IEnumerable<LocationIQ>> GetLocationIQ(string address)
        {
            string addressConverted = address;
            var response = await Client.GetAsync(
                "search.php?key=" + Constants.Constants.LOCATION_IQ_API_KEY + "&q=" + addressConverted + "&format=json");

            response.EnsureSuccessStatusCode();

            try
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<LocationIQ>>(responseStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at GetLocationIQ(string address): " + ex.Message);
                return null;
            }
        }
    }
}
