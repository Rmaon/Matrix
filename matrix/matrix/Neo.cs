using System;
namespace matrix
{
    public class Neo : Npc
    {
        public bool Believe { get; set; } // Propiedad sólo de lectura.

        public Neo()
        {
            Name = "Neo";

            Random random = new Random();
            Believe = random.Next(2) == 0; // Genera un valor aleatorio entre 0 y 1. Si es 0, Believe es false; si es 1, Believe es true.
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            return $"Nombre: {Name}, DeathP: {DeathP}, Elegido: {Believe} Location: {location} ";
        }


    }
}