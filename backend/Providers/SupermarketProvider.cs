using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;
using backend.Models.Filters;
using backend.Repository;

namespace backend.Providers
{
    public static class SupermarketProvider
    {
        
        public static List<Supermarket> FetchSupermarkets(SupermarketFilter supermarketFilter)
        {
            List<Supermarket> supermarketList = new List<Supermarket>();
            using (PostgreSQLDBContext context = new PostgreSQLDBContext())
            {
                List<Shop> shops = context.Shop.ToList();
                int a = 2;
            }
    
            supermarketList = supermarketList.OrderBy(x => x.distance).ToList();
            return supermarketList;
        }
    }
}
