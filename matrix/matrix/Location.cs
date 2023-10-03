using System;
using System.Collections.Generic;
namespace matrix
{

    public class Location
    {
        public int Longitude { get; private set; }
        public int Latitude { get; private set; }
        public string City { get; private set; }

        private static Random random = new Random();
        private static List<string> cities = new List<string>
    {
        "Madrid", "Barcelona", "Sevilla", "Valencia",
        "Zaragoza", "Málaga", "Murcia", "Bilbao", "Nueva York",
        "Boston","Baltimore", "Atlanta", "Detroit", "Dallas", "Denver","Guarroman"
    };

        public Location(int maxLongitude, int maxLatitude, bool[,] takenLocations)
        {
            do
            {
                Longitude = random.Next(0, maxLongitude + 1);
                Latitude = random.Next(0, maxLatitude + 1);
            } while (IsTaken(Longitude, Latitude, takenLocations));

            City = cities[random.Next(cities.Count)];
        }

        public Location(int x, int y)
        {
            Longitude = x;
            Latitude = y;
            City = cities[random.Next(cities.Count)];
        }

        private bool IsTaken(int longitude, int latitude, bool[,] locations)
        {
            if (longitude < locations.GetLength(0) && latitude < locations.GetLength(1))
                return locations[longitude, latitude];
            return false;
        }

        public override string ToString()
        {
            return $"Ciudad: {City}, x: {Longitude}, y: {Latitude}";
        }
    }
}