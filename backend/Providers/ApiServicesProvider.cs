using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Models.ApiServices;
using backend.Providers.ApiServices;
using backend.Providers.Interfaces;
using backend.Utils;

namespace backend.Providers
{
    /**
     * Api provider service class
     * Manages all the requests to third party api's
     */
    public class ApiProvider : IApiProvider
    {
        private readonly LocationIQApiService _locationIQApiService;
        private readonly GoogleMapsApiService _googleMapsApiService;

        public ApiProvider(LocationIQApiService locationIQApiService, GoogleMapsApiService googleMapsApiService)
        {
            _locationIQApiService = locationIQApiService;
            _googleMapsApiService = googleMapsApiService;
        }

        /**
         * Gets the latitude and longitude given an address
         */
        public async Task<GeoCoordinate> GetGeocoordinateFromAddress(string address)
        {
            IEnumerable<LocationIQ> locationIQs = await _locationIQApiService.GetLocationIQ(address);
            if (locationIQs != null)
            {
                List<LocationIQ> locationIQList = locationIQs.ToList();

                //there should be just one response
                if (locationIQList.Count == 0)
                {
                    throw new Exception("No results found");
                }
                else
                {
                    //if there is more than one possible location, we take the first one
                    return new GeoCoordinate(Convert.ToDouble(locationIQList[0].lat), Convert.ToDouble(locationIQList[0].lon));
                }
            }
            else
            {
                return null;
            }
        }

        /**
         * Gets all the groceries and supermarkets for a given location
         */
        public async Task<IEnumerable<Supermarket>> GetSupermarketsFromLocation(GeoCoordinate location)
        {
            List<Supermarket> supermarkets = new List<Supermarket>();

            GooglePlacesObject rootResults = await _googleMapsApiService.GetSupermarkets(location);
            if (rootResults != null)
            {
                List<GoogleSupermarket> googleSupermarketList = rootResults.results;

                if (googleSupermarketList.Count == 0)
                {
                    throw new Exception("No results found");
                }
                else
                {
                    Supermarket supermarket;
                    GeoCoordinate currentLocation;
                    foreach (GoogleSupermarket googleSupermarket in googleSupermarketList)
                    {

                        currentLocation = new GeoCoordinate(googleSupermarket.geometry.location.lat, googleSupermarket.geometry.location.lng);
                        supermarket = new Supermarket()
                        {
                            id = googleSupermarket.id,
                            name = googleSupermarket.name,
                            address = googleSupermarket.vicinity,
                            location = currentLocation,
                            distance = LocationUtils.CalculateDistance(location, currentLocation)
                        };
                        supermarkets.Add(supermarket);
                    };
                }

                return supermarkets.OrderBy(x => x.distance).ToList();
            }
            else
                return supermarkets;

        }
    }
}
