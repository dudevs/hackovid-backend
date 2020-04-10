using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Providers.Interfaces
{
    public interface ISupermarketProvider
    {
        Task<IEnumerable<Supermarket>> FetchSupermarketsByAddress(string address);

        Task<IEnumerable<Supermarket>> FetchSupermarketsByLocation(GeoCoordinate location);
    }
}
