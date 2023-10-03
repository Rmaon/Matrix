using System;
using System.Collections.Generic;
namespace matrix
{

    public class Npc
    {
        //Propiedades de Npc, donde DeathP es la posibilidad de muerte, Name el nombre que coge de la lista de nombres dada a continuacion y 
        //location instancia la clase Location para asiganarsela a cada NPC
        public int DeathP { get; set; }
        public string Name { get; set; }
        public Location location { get; set; }

        private static Random random = new Random();
        private static List<string> names = new List<string>
    {
            "Manolo", "Pepa", "Bartolo", "Rosario",
            "Antoñito", "Carmen", "Esteban", "Josefa", "Michelle", "Alexander", "James", "Caroline",
            "Claire", "Jessica", "Erik", "Mike", "Dolores", "Paco", "Inés", "Fernando",
            "Isabel", "Juan", "Lola", "Miguel", "Ana", "Francisco", "Teresa", "Carlos",
            "Pilar", "Javier", "Consuelo", "Pedro", "Catalina", "Luís", "María", "José",
            "Felipe", "Esperanza", "Alberto", "Beatriz", "Alfonso", "Rosa", "Federico", "Lucía",
            "Ignacio", "Mercedes", "Victor", "Soledad", "Enrique", "Juana", "Andrés", "Marta",
            "Ramón", "Blanca", "Gabriel", "Lourdes", "Sergio", "Elena", "Joaquín", "Raquel"

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
        //ToString con formato de colores
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            return $"Nombre: {Name}, DeathP: {DeathP}, Location: {location}";
        }
    }

}