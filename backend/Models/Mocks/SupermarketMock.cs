using System;
using System.Collections.Generic;

namespace backend.Models.Mocks
{
    public class SupermarketMock : Supermarket
    {
        private List<string> supermarketNames = new List<string>() {"Lil' shop", "Mercadona", "Mohamed shop", "Lidl", "Pepe alimentació", "Fish and fish", "Verdures i fruites Tomàs"};
        private List<string> addresses = new List<string> {
            "Carrer de la farigola, 35",
            "Carrer de la farigola, 69",
            "Carrer monturiol, 123",
            "Carrer sant ramon, 34",
            "Carrer sant ramon, 56",
            "Plaça dels fatxes, 99"};

        private List<string> cities = new List<string>{"LA", "Terrassa", "Cerdanyola"};

        public SupermarketMock()
        {
            var random = new Random();
            name = supermarketNames[random.Next(supermarketNames.Count)];
            address = addresses[random.Next(addresses.Count)];
            city = cities[random.Next(cities.Count)];
            double lat = random.NextDouble() * (Constants.Constants.MAX_LATITUDE - Constants.Constants.MIN_LATITUDE) + Constants.Constants.MIN_LATITUDE;
            double lng = random.NextDouble() * (Constants.Constants.MAX_LONGITUDE - Constants.Constants.MIN_LONGITUDE) + Constants.Constants.MIN_LONGITUDE;
            location = new GeoCoordinate(lat, lng);
            distance = random.Next(0, Constants.Constants.MAX_DISTANCE_METERS);
        }
    }
}
