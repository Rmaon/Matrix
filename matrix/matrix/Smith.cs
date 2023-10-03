using System;
namespace matrix
{
    public class Smith : Npc
    {
        public decimal InfectCap { get; private set; }

        public Smith()
        {
            Name = "Smith";
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            return $"Nombre: {Name}, KillP: {DeathP}, Location: {location}";
        }
    }
}