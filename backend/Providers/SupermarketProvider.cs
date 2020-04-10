using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using backend.Providers.Interfaces;

namespace backend.Providers
{
    public class SupermarketProvider : ISupermarketProvider
    {
        IApiProvider _apiProvider;
        public SupermarketProvider(IApiProvider apiProvider)
        {
            _apiProvider = apiProvider;
        }


        public async Task<IEnumerable<Supermarket>> FetchSupermarketsByAddress(string address)
        {
            IEnumerable<Supermarket> supermarketList = new List<Supermarket>();

            try
            {
                GeoCoordinate location = await _apiProvider.GetGeocoordinateFromAddress(address);
                supermarketList = await _apiProvider.GetSupermarketsFromLocation(location);
            }
            catch (Exception ex)
            {
                //no results found
                //TODO: log error
            }

            return supermarketList;
        }

        public async Task<IEnumerable<Supermarket>> FetchSupermarketsByLocation(GeoCoordinate location)
        {
            IEnumerable<Supermarket> supermarketList = new List<Supermarket>();

            try
            {
                supermarketList = await _apiProvider.GetSupermarketsFromLocation(location);
            }
            catch (Exception ex)
            {
                //no results found
                //TODO: log error
            }

            return supermarketList;
        }
    }
}
