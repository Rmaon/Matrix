using System;
using System.Collections.Generic;
namespace matrix
{

    public class Matrix

    {
        NpcFactory factory = new NpcFactory();
        private int cont;
        private Npc[,] matrixArray;

        public int Cont
        {
            get { return cont; }
            set { cont = value; }
        }

        public Npc[,] MatrixArray
        {
            get { return matrixArray; }
            set { matrixArray = value; }
        }

        public Matrix(int matrixT)
        {
            matrixArray = new Npc[matrixT, matrixT];
            cont = 0;
        }

        public void DisplayNpc()
        {
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i,j]==null)
                    {}
                    else
                    {
                        Console.Write(matrixArray[i, j].ToString());
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    }
            }
        }

        public void MovimientoNpc()
        {
            String registro = null;

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i, j] == null)
                    { }
                    else
                    {
                        if (matrixArray[i, j] is Npc)
                        {
                            if (matrixArray[i, j] is Neo | matrixArray[i, j] is Smith){}
                            else
                            {
                                if (matrixArray[i, j].DeathP >= 7)
                                {
                                    registro += $"Se ha muerto {matrixArray[i, j].Name} ya que su porcentaje de muerte era demasiado alto.\n";
                                    cont++;
                                    matrixArray[i, j] = new Npc(i, j);
                                }
                                else
                                {
                                    matrixArray[i, j].DeathP ++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("\n"+registro);
        }

        public void MovimientoSmith(bool endgame,int nMaxNpc)
        {
            Random random = new Random();
            String registro=null;
            Boolean xCheck=false,yCheck=false,salirM=true, believe;
            int xFirst = 0, xSmith = 0, yFirst = 0, ySmith = 0, xNeo = 0, yNeo = 0, killP = 0, deathNeo = 0, localCont = 0; 

            for(int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for(int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i,j] is Smith)
                    {
                        xSmith = matrixArray[i, j].location.Longitude;
                        xFirst = xSmith;
                        ySmith = matrixArray[i, j].location.Latitude;
                        yFirst = ySmith;
                        matrixArray[i, j].DeathP = random.Next(1, 11);
                        killP = matrixArray[i, j].DeathP;
                        Console.Write($"El porcentaje de asesinato de Smith es {killP} en esta ronda");

                    }
                }
            }

            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i, j] is Neo)
                    {
                        xNeo = matrixArray[i, j].location.Longitude;
                        yNeo = matrixArray[i, j].location.Latitude;
                        deathNeo = matrixArray[i, j].DeathP;
                        Neo neoVar = matrixArray[i, j] as Neo;
                        believe = neoVar.Believe;
                    }
                }
            }
            try
            {
                do
                {
                    if (cont == nMaxNpc)
                    {
                        Console.Write("Smith ha matado a suficientes ciudadanos, se acaba el juego");
                        break;
                    }

                    if (xSmith >= xNeo)
                    {
                        xCheck = true;
                    }
                    if (ySmith >= yNeo)
                    {
                        yCheck = true;
                    }

                    if (xCheck)
                    {
                        if (xSmith == 0)
                        {
                            xSmith++;
                        }
                        else
                        {
                            xSmith--;
                        }
                    }
                    else
                    {
                        xSmith++;
                    }

                    if (yCheck)
                    {

                        if (ySmith == 0)
                        {
                            ySmith++;
                        }
                        ySmith--;
                    }
                    else
                    {
                        ySmith++;
                    }
                    if (matrixArray[xSmith, ySmith] is Neo)
                    {
                        Neo neoVar = matrixArray[xSmith, ySmith] as Neo;

                        if (killP + matrixArray[xSmith, ySmith].DeathP >= 10 && neoVar.Believe)
                        {
                            registro += $"Smith ha matado a {matrixArray[xSmith, ySmith].Name}.\n";
                            cont++;
                            endgame = true;
                            Console.Write("FIN DEL JUEGO");
                            break;
                        }
                    }
                    if (matrixArray[xSmith, ySmith] is Smith)
                    {
                        salirM = false;
                    }
                    else
                    {
                        if (matrixArray[xSmith, ySmith] is Npc)
                        {
                            if (killP + matrixArray[xSmith, ySmith].DeathP >= 10)
                            {
                                registro += $"Smith ha matado a {matrixArray[xSmith, ySmith].Name}.\n";
                                localCont++;
                                cont++;
                            }
                        }

                    }


                    if (Math.Abs(xSmith - xNeo) <= 1 && Math.Abs(ySmith - yNeo) <= 1)
                    {
                        if (matrixArray[xSmith, ySmith] is Npc)
                        {
                            Npc temp = matrixArray[xSmith, ySmith];
                            matrixArray[xSmith, ySmith] = matrixArray[xFirst, yFirst];
                            matrixArray[xFirst, yFirst] = temp;
                        }
                        else
                        {
                            matrixArray[xSmith, ySmith] = matrixArray[xFirst, yFirst];
                            matrixArray[xFirst, yFirst] = null;
                        }

                        Neo neoVar = matrixArray[xNeo, yNeo] as Neo;
                        if (killP + matrixArray[xSmith, ySmith].DeathP >= 10 && neoVar.Believe)
                        {
                            registro += $"Smith ha matado a {matrixArray[xSmith, ySmith].Name}.\n";
                            cont++;
                            endgame = true;
                            Console.Write("FIN DEL JUEGO");
                            break;
                        }

                        factory.GenerarNpcs(matrixArray, localCont);
                        salirM = false;
                    }
                } while (salirM);
            }
            catch (Exception ex)
            {

            }


            Console.WriteLine("\n" + registro);
        }

        public void MovimientoNeo()
        {
            Neo neoVar=null;
            int[] dx = { -1, 0, 1, 0, -1, 1, -1, 1 };
            int[] dy = { 0, -1, 0, 1, -1, -1, 1, 1 };
            int xNeo=0, yNeo=0,newX=0,newY=0;
            Boolean creer=true;
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i, j] is Neo)
                    {
                        xNeo = matrixArray[i, j].location.Longitude;
                        yNeo = matrixArray[i, j].location.Latitude;
                        neoVar = matrixArray[i, j] as Neo;

                        Random random = new Random();
                        neoVar.Believe = random.Next(2) == 0;
                        creer = neoVar.Believe;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                newX = xNeo + dx[i];
                newY = yNeo + dy[i];

                if (creer && newX > 0 && newX < matrixArray.GetLength(0) && newY > 0 && newY < matrixArray.GetLength(1))
                {
                    if (matrixArray[newX, newY] != null)
                    {
                        matrixArray[newX, newY] = new Npc();
                        cont++;
                        break;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                newX = xNeo + dx[i];
                newY = yNeo + dy[i];
                if (newX > 0 && newX < matrixArray.GetLength(0) && newY > 0 && newY < matrixArray.GetLength(1))
                {
                    if (matrixArray[newX, newY] != null)
                    {
                        matrixArray[newX, newY] = neoVar;
                        matrixArray[xNeo, yNeo] = null;
                        break;
                    }
                }
            }

            Console.WriteLine("\n Neo se ha movido de la celda x->"+ xNeo +" y->" + yNeo + " a la celda x->"+newX+" y->"+newY);

        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < matrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrixArray.GetLength(1); j++)
                {
                    if (matrixArray[i, j] == null)
                    {
                        Console.BackgroundColor = ConsoleColor.Black; 
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write("[   ]");
                    }
                    else if (matrixArray[i, j] is Neo)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen; 
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write("[ n ]");
                    }
                    else if (matrixArray[i, j] is Smith)
                    {
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write("[ s ]");
                    }
                    else // Si es un NPC genérico
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue; 
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write("[ x ]");
                    }

                    // Restablece los colores a los valores por defecto después de escribir
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }
}