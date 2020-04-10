using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Providers.Interfaces
{
    public interface IApiProvider
    {
        Task<GeoCoordinate> GetGeocoordinateFromAddress(string address);

        Task<IEnumerable<Supermarket>> GetSupermarketsFromLocation(GeoCoordinate location);
    }
}
