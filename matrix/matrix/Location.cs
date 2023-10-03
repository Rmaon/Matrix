using System;
using System.Collections.Generic;
namespace matrix
{

    public class Location//clase location, aquí se guardan las coordenadas y una ciudad a cada personaje
    {
        public int Longitude { get; private set; }
        public int Latitude { get; private set; }
        public string City { get; private set; }

        private static Random random = new Random();
        private static List<string> cities = new List<string>
    {
        "Madrid", "Barcelona", "Sevilla", "Valencia",
        "Zaragoza", "Málaga", "Murcia", "Bilbao", "Nueva York",
        "Boston","Baltimore", "Atlanta", "Detroit", "Dallas", "Denver","Guarroman",
        "Toledo", "Ciudad Real", "Cuenca", "Albacete", "Guadalajara",
        "Talavera de la Reina", "Alcázar de San Juan", "Puertollano", "Hellín", "Valdepeñas",
        "Villarrobledo", "Tomelloso", "Manzanares", "Daimiel", "Mota del Cuervo",
        "Almansa", "Sigüenza", "Almagro", "Chinchilla de Monte-Aragón", "Villanueva de los Infantes",
        "Ocaña", "Uclés", "Illescas", "Seseña", "Esquivias",

    };
        //Constructor en el que se le pasan las dimensiones maximas y una matrix copia de la principal
        public Location(int maxLongitude, int maxLatitude, bool[,] takenLocations)
        {
            do
            {
                Longitude = random.Next(0, maxLongitude + 1);
                Latitude = random.Next(0, maxLatitude + 1);
            } while (IsTaken(Longitude, Latitude, takenLocations));

            City = cities[random.Next(cities.Count)];
        }
        //constructor basico, para poner unas coordenadas ya comprobadas
        public Location(int x, int y)
        {
            Longitude = x;
            Latitude = y;
            City = cities[random.Next(cities.Count)];
        }
        //Validador que compruba si una posicion ya está tomada, que se usa en el constructor principal
        private bool IsTaken(int longitude, int latitude, bool[,] locations)
        {
            if (longitude < locations.GetLength(0) && latitude < locations.GetLength(1))
                return locations[longitude, latitude];
            return false;
        }
        //ToString autogenerado con unas pequeñas modificaciones
        public override string ToString()
        {
            return $"Ciudad: {City}, x: {Longitude}, y: {Latitude}";
        }
    }
}