using System;
namespace matrix
{
    public class Smith : Npc
    {
        public decimal InfectCap { get; private set; }

        public Smith()
        {            //Ya se declara el nombre como Smith, para que no coja ninguno de la lista

            Name = "Smith";
        }
        //ToString con formato de colores

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            return $"Nombre: {Name}, KillP: {DeathP}, Location: {location}";
        }
    }
}