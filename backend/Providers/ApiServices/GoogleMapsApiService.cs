using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Models;
using backend.Models.ApiServices;

namespace backend.Providers.ApiServices
{
    public class GoogleMapsApiService
    {
        public HttpClient Client { get; }

        public GoogleMapsApiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");

            Client = client;
        }

        public async Task<GooglePlacesObject> GetSupermarkets(GeoCoordinate location)
        {
            var response = await Client.GetAsync(
                "place/nearbysearch/json?" +
                "location=" + location.Lat + "," + location.Lng +
                "&radius=" + Constants.Constants.MAX_DISTANCE_METERS +
                "&type=grocery_or_supermarket" +
                "&key=" + Constants.Constants.GOOGLE_MAPS_API_KEY);

            response.EnsureSuccessStatusCode();

            try
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<GooglePlacesObject>(responseStream);
            }
            catch (Exception ex)
            {
                //TODO: log error
                int a = 1;
                return null;
            }
        }
    }
}
