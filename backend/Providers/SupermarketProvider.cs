using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;
using backend.Models.Filters;
using backend.Models.Mocks;

namespace backend.Providers
{
    public static class SupermarketProvider
    {
        public static List<Supermarket> FetchSupermarkets(SupermarketFilter supermarketFilter)
        {
            List<Supermarket> supermarketList = new List<Supermarket>();
            int items = new Random().Next(1, 10);
            for (int i = 0; i < items; i++)
            {
                supermarketList.Add(new SupermarketMock());
                i++;
            }

            supermarketList = supermarketList.OrderBy(x => x.distance).ToList();
            return supermarketList;
        }
    }
}
