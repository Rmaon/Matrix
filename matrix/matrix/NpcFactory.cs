using System;
namespace matrix
{
    // Esta clase es una fábrica para generar y colocar NPCs, Neo y Smith en una matriz.
    public class NpcFactory
    {
        // Generador de números aleatorios para posicionar los NPC de manera aleatoria.
        private Random random = new Random();

        // Método para generar una nueva matriz de NPC con el tamaño especificado.
        public Npc[,] GenerarMatrix(int size)
        {
            return new Npc[size, size];
        }

        // Coloca un NPC (o cualquier derivado de él) en una posición aleatoria de la matriz.
        private void ColocarEnPosicionAleatoria(Npc[,] matrix, Npc npc)
        {
            int intentos = 0; // Variable para controlar el número de intentos de colocación.
            bool nope = true; // Bandera para controlar si la colocación es posible.
            int size = matrix.GetLength(0); // Obteniendo el tamaño de la matriz.
            int x, y; // Variables para almacenar las coordenadas en las que se intentará colocar el NPC.

            do
            {
                // Generando coordenadas aleatorias.
                x = random.Next(size);
                y = random.Next(size);

                // Si se han hecho 20 intentos para colocar el NPC y no se ha podido, se sale del bucle.
                if (intentos == 20)
                {
                    nope = false; // Indica que no se pudo colocar el NPC.
                    break;
                }

                // Se repite mientras la posición generada ya esté ocupada.
            } while (matrix[x, y] != null);

            if (nope)
            {
                matrix[x, y] = npc; 
                matrix[x, y].location = new Location(x, y);
            }
        }

        // Genera un número específico de NPCs en la matriz.
        public void GenerarNpcs(Npc[,] matrix, int count)
        {
            for (int i = 0; i < count; i++)
            {
                ColocarEnPosicionAleatoria(matrix, new Npc());
            }
        }

        // Genera y coloca un Smith en una posición aleatoria de la matriz.
        public void GenerarSmith(Npc[,] matrix)
        {
            ColocarEnPosicionAleatoria(matrix, new Smith());
        }

        // Genera y coloca un Neo en una posición aleatoria de la matriz.
        public void GenerarNeo(Npc[,] matrix)
        {
            ColocarEnPosicionAleatoria(matrix, new Neo());
        }
    }
}
