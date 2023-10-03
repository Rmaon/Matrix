using System;
namespace matrix
{
    public class NpcFactory
    {
        private Random random = new Random();

        public Npc[,] GenerarMatrix(int size)
        {
            return new Npc[size, size];
        }

        private void ColocarEnPosicionAleatoria(Npc[,] matrix, Npc npc)
        {
            int intentos=0;
            bool nope=true;
            int size = matrix.GetLength(0);
            int x, y;
            do
            {
                x = random.Next(size);
                y = random.Next(size);
                if (intentos==20)
                {
                    nope = false;
                    break;
                }

            } while (matrix[x, y] != null); // Encuentra una posición sin ocupar
            if (nope)
            {
                matrix[x, y] = npc;
                // Estableciendo la ubicación del NPC:
                matrix[x, y].location = new Location(x, y);
            }

           
        }

        public void GenerarNpcs(Npc[,] matrix, int count)
        {
            for (int i = 0; i < count; i++)
            {
                ColocarEnPosicionAleatoria(matrix, new Npc());
            }
        }

        public void GenerarSmith(Npc[,] matrix)
        {
            ColocarEnPosicionAleatoria(matrix, new Smith());
        }

        public void GenerarNeo(Npc[,] matrix)
        {
            ColocarEnPosicionAleatoria(matrix, new Neo());
        }
    }
}