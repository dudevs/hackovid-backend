using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Providers.Interfaces
{
    /*
     * Interface for supermarkets provider
     */
    public interface ISupermarketProvider
    {
        bool CheckDatabaseConnection();

        Task<IEnumerable<Supermarket>> FetchSupermarketsByAddress(string address);

        Task<IEnumerable<Supermarket>> FetchSupermarketsByLocation(GeoCoordinate location);

        IEnumerable<SupermarketData> GetSupermarketDataById(string id);

        bool VoteBasicGood(string id, string basicGood, bool status);
    }
}
