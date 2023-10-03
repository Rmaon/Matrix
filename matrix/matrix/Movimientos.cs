using System;
namespace matrix
{
    public class Movimientos
    {
       public void MovimientoNpc(Npc[,] matrix)
        {

            String registro= null;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); i++)
                {
                    if (matrix[i,j] == null)
                    { }
                    else if (matrix[i,j] is Npc)
                    {
                        if (matrix[i,j].DeathP >=7)
                        {
                            registro += $"Se ha muerto {matrix[i,j].Name} ya que su porcentaje de muerte era demasiado alto.\n";

                            matrix[i, j] = new Npc(i,j);
                        }
                    }
                }
            }
            Console.WriteLine(registro);
        }
    }
}
