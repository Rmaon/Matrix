using System;
using System.Collections.Generic;
namespace matrix
{

    public class Matrix

    {
        //Lama a la factory, crea un contador porpio y una matriz para trabajar con ella
        NpcFactory factory = new NpcFactory();
        private int cont;
        private Npc[,] matrixArray;

        public int Cont
        {
            get { return cont; }
            set { cont = value; }
        }

        public Npc[,] MatrixArray//Hace una matriz de tipo Npc como una de sus propiedades
        {
            get { return matrixArray; }
            set { matrixArray = value; }
        }

        public Matrix(int matrixT)//Constructor de la matriz que la hace vacia
        {
            matrixArray = new Npc[matrixT, matrixT];
            cont = 0;
        }

        public void DisplayNpc()//Metodo para mostrar los NPC que componen la matriz
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

        public void MovimientoNpc()//Metodo que hace las operaciones necesarias en el turno del NPC
        {
            String registro = null;
            //Doble bucle for que recorre la matriz para localizar a cada NPC
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
                            if (matrixArray[i, j] is Neo | matrixArray[i, j] is Smith){}//Comprueba que no sean ni Neo ni Smith
                            else
                            {
                                if (matrixArray[i, j].DeathP >= 7)//Si la posibilidad es mayor que 7 los mata directamente, si no la aumenta un 10%
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

        public void MovimientoSmith(bool endgame,int nMaxNpc)//Meotodo que engloba todas las operaciones de Smith
        {
            //Se declaran variables locales necesarias para las siguientes operaciones
            Random random = new Random();
            String registro=null;
            Boolean xCheck=false,yCheck=false,salirM=true, believe;
            int xFirst = 0, xSmith = 0, yFirst = 0, ySmith = 0, xNeo = 0, yNeo = 0, killP = 0, deathNeo = 0, localCont = 0; 
            //Doble bucle for que recorre la array para determinar la posicion de smith y darle una posiblidad de matar nueva
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
            //Doble bucle for que recorre la array para determinar la posicion de Neo y el boolean believe
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
                    if (cont >= nMaxNpc)//Antes de ejecutar ningun movimiento comprueba que ya se hayan matado suficientes ciudadanos
                    {
                        Console.Write("Smith ha matado a suficientes ciudadanos, se acaba el juego");
                        break;
                    }
                    //se determina la posicion de cada uno tomando como eje a Smith
                    if (xSmith >= xNeo)
                    {
                        xCheck = true;
                    }
                    if (ySmith >= yNeo)
                    {
                        yCheck = true;
                    }

                    //dependiendo de la posicion de los dos se mueve a Smith hacia un lado o otro, pero siempre en cruz y comprobando que no salga de los limites
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
                    //si alcanza a neo hace una comprobacion para matarlo
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
                    //Comprueba que no se de una redundancia al matarse a si mismo, ya que si ya a alcanzado a Neo lo rodeará
                    if (matrixArray[xSmith, ySmith] is Smith)
                    {
                        salirM = false;
                    }
                    else
                    //Si ya se han comprobado las dos anteriores comprueba si es un Npc y si puede matarlo, si la suma de las dos posibilidades es mayor que 10
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
                    try
                    {
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
                            //genera los npc que ha matado neo
                            factory.GenerarNpcs(matrixArray, localCont);
                            salirM = false;
                        }
                    }//Catch que si se da una referencia nula, permite al programa obviarlo y continuar la ejecucion
                    catch (System.NullReferenceException ex)
                    {

                    }
                    //Aquí comprueba que ya esta al lado, para intentar matar a Neo y para cambiar su posicion con la de un NPC que no haya podido matar
                   
                } while (salirM);
            }//un catch para una excepcion que me dio una vez
            catch (InvalidCastException ex)
            {
            }
            //Escribe un registro con todos los Npc que ha matado Smith
            Console.WriteLine("\n" + registro);
        }

        public void MovimientoNeo()//Metodo con los movimientos de Neo
        {
            //Decalro un par de varibles y valores locales que voy a usar, como las dos arrays que son las coordenadas que roodean a Neo
            Neo neoVar=null;
            int[] dx = { -1, 0, 1, 0, -1, 1, -1, 1 };
            int[] dy = { 0, -1, 0, 1, -1, -1, 1, 1 };
            int xNeo=0, yNeo=0,newX=0,newY=0;
            Boolean creer=true;

            for (int i = 0; i < matrixArray.GetLength(0); i++)//Doble bucle for que busca a Neo para determinar sus valores 
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

            for (int i = 0; i < 8; i++)//bucle for que recorre las dos arrays de posiciones que he calado arriba para comprobar los valores que roodean a neo y si puede generar un NPC
            {
                newX = xNeo + dx[i];
                newY = yNeo + dy[i];

                if (creer && newX > 0 && newX < matrixArray.GetLength(0) && newY > 0 && newY < matrixArray.GetLength(1))
                {
                    if (matrixArray[newX, newY] != null)
                    {
                        matrixArray[newX, newY] = new Npc();
                        cont++;
                        Console.Write($"Neo a generado un Npc en la posicion x->{newX} y->{newY} ");
                        break;
                    }
                }
            }
            for (int i = 0; i < 8; i++)//Bucle que al igual que el anterior, comprueba las casillas que roodean a Neo y comprueba si se puede mover a una al lado suya
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

        public void DisplayMatrix() //Metodo que pinta la matrix, aplicando colores
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
                        Console.BackgroundColor = ConsoleColor.DarkGray;
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