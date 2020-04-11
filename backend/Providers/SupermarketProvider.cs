using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Providers.Interfaces;
using backend.Repository;
using Npgsql;

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
                int savedRows = SaveSupermarkets(supermarketList.ToList());
                
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
                int savedRows = SaveSupermarkets(supermarketList.ToList());
            }
            catch (Exception ex)
            {
                //no results found
                //TODO: log error
            }

            return supermarketList;
        }

        public bool CheckDatabaseConnection()
        {
            bool isThereConnection = false;
            using (PostgreContext context = new PostgreContext())
            {
                isThereConnection = 0 < context.GroupTypes.Count();
            }
            return isThereConnection;
        }

        public IEnumerable<SupermarketData> GetSupermarketDataById(string id)
        {
            List<SupermarketData> supermarketDataList = new List<SupermarketData>();

            using (PostgreContext context = new PostgreContext())
            {
                IEnumerable<IGrouping<string, LastFourHours>> lastFourHours = context.LastFourHours.Where(x => x.Idshop.Equals(id)).ToList().GroupBy(x => x.Groupname);
                lastFourHours.SelectMany(group => group);

                foreach (IGrouping<string, LastFourHours> entry in lastFourHours)
                {
                    SupermarketData supermarketData = new SupermarketData();
                    List<BasicGoodStatus> basicGoodStatuses = new List<BasicGoodStatus>();

                    string key = entry.Key;
                    foreach (LastFourHours item in entry)
                    {
                        BasicGoodStatus basicGoodStatus = new BasicGoodStatus()
                        {
                            timestamp = decimal.ToInt64(item.Unixtime ?? 0),
                            upvote = decimal.ToInt32(item.Positives ?? 0),
                            downvote = decimal.ToInt32(item.Negatives ?? 0)
                        };

                        basicGoodStatuses.Add(basicGoodStatus);
                    }

                    supermarketData.item = key;
                    supermarketData.timeline = basicGoodStatuses;

                    supermarketDataList.Add(supermarketData);
                }
            }

            return supermarketDataList;
        }

        public bool VoteBasicGood(string id, string basicGood, bool status)
        {
            bool voteRegistered = false;

            using (var conn = new NpgsqlConnection(Constants.Constants.PostgreConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("supermarket.vote", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Text, id);
                    cmd.Parameters.AddWithValue("@basicgood", NpgsqlTypes.NpgsqlDbType.Text, basicGood);
                    cmd.Parameters.AddWithValue("@vote", NpgsqlTypes.NpgsqlDbType.Boolean, status);
                    try
                    {
                        var ret = (int)cmd.ExecuteScalar();
                        voteRegistered = ret != 0;  //0 means no modified rows
                    }
                    catch (Exception ex)
                    {
                        //TODO register error
                        int a = 2;
                    }
                }
            }
            return voteRegistered;
        }

        private int SaveSupermarkets(List<Supermarket> supermarkets)
        {
            int rowsAffected = 0;
            using (PostgreContext context = new PostgreContext())
            {
                List<Shop> shopsToStore = new List<Shop>();

                foreach (Supermarket supermarket in supermarkets)
                {
                    bool supermarketAlreadyExists = context.Shop.Where(x => x.Id.Equals(supermarket.id)).Count() != 0;
                    if (!supermarketAlreadyExists)
                    {
                        Shop shop = new Shop()
                        {
                            Id = supermarket.id,
                            Nom = supermarket.name,
                            Address = supermarket.address,
                            City = "",
                            Latitude = supermarket.location.Lat,
                            Longitude = supermarket.location.Lng
                        };
                        shopsToStore.Add(shop);
                    }
                }

                if (shopsToStore.Count != 0)
                {
                    context.AddRange(shopsToStore);
                    rowsAffected = context.SaveChanges();
                }
            }

            return rowsAffected;
        }
    }
}
