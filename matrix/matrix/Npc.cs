using System;
using System.Collections.Generic;
namespace matrix
{

    public class Npc
    {
        public int DeathP { get; set; }
        public string Name { get; set; }
        public Location location { get; set; }

        private static Random random = new Random();
        private static List<string> names = new List<string>
    {
        "Manolo", "Pepa", "Bartolo", "Rosario",
        "Antoñito", "Carmen", "Esteban", "Josefa","Michelle", "Alexander", "James", "Caroline",
        "Claire", "Jessica", "Erik", "Mike"
    };

        public Npc()
        {
            DeathP = random.Next(1, 11); // Genera un valor entre 1 y 10
            Name = names[random.Next(names.Count)]; // Selecciona un nombre aleatorio de la lista
        }

        public Npc(int x,int y)
        {
            DeathP = random.Next(1, 11); // Genera un valor entre 1 y 10
            Name = names[random.Next(names.Count)]; // Selecciona un nombre aleatorio de la lista

            location = new Location(x,y);
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            return $"Nombre: {Name}, DeathP: {DeathP}, Location: {location}";
        }
    }

}