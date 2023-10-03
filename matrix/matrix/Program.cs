using System;
namespace matrix
{

    class MainClass
    {

        //Aquí declaro las variables con las que voy a construir la matrix
        public const int matrixT = 5;   //Tamaño de la misma
        public const int nNpc =10;      //El numero de npc iniciales
        public const int nMaxNpc = 20;  //El numero maximo de npcs que pueden morir, si mueren mas acaba el juego

        //Aquí declaro un contador que luego instanciare en la matrix
        public static int cont = 0;

        public static void Main(string[] args)
        {
            //Un boolean para controlar el final del juego.
            bool endgame = false;
            //Invoco al Factory 
            NpcFactory factory = new NpcFactory();

            Npc[,] npcArray = factory.GenerarMatrix(size: matrixT); //Genera una matriz del tamaño de matrixT

            factory.GenerarNpcs(npcArray, nNpc); // Genera n NPCs genéricos
            factory.GenerarSmith(npcArray);   // Genera 1 Smith
            factory.GenerarNeo(npcArray);     // Genera 1 Neo 

            //Istancio la matriz para trabajar sobre ella
            Matrix matrixInstance = new Matrix(matrixT);
            matrixInstance.MatrixArray = npcArray;


            //bucle for con los turnos
            for (int i = 1; i <= 20; i++)
            {
                //Un if, en el que si se cumple añguna de estas dos posibilidades termina el juego
                if (matrixInstance.Cont >= nMaxNpc || endgame)
                {
                    Console.Write("Han muerto demasiados humanos, se termina el juego...");
                    i = 21;
                    break;
                }
                else
                {
                    Console.WriteLine("Turno nº" + i);
                }

                switch (i)
                {
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                    case 12:
                    case 14:
                    case 16:
                    case 18:
                        matrixInstance.MovimientoSmith(endgame, nMaxNpc);
                        matrixInstance.DisplayMatrix();
                        matrixInstance.DisplayNpc();
                        matrixInstance.MovimientoNpc();
                        break;

                    case 10:
                    case 20:
                        matrixInstance.MovimientoNeo();
                        matrixInstance.MovimientoSmith(endgame, nMaxNpc);
                        matrixInstance.DisplayMatrix();
                        matrixInstance.DisplayNpc();
                        matrixInstance.MovimientoNpc();
                        break;

                    case 5:
                    case 15:
                        matrixInstance.MovimientoNeo();
                        matrixInstance.DisplayMatrix();
                        matrixInstance.DisplayNpc();
                        matrixInstance.MovimientoNpc();
                        break;
                    case 21:
                        Console.Write("Se ha terminado el juego...");
                        break;
                    default:
                        matrixInstance.DisplayMatrix(); 
                        matrixInstance.DisplayNpc();
                        matrixInstance.MovimientoNpc();
                        break;

                }
            }
        }
    }
}