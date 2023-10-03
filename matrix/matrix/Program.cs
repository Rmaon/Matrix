using System;
namespace matrix
{

    class MainClass
    {


        public const int matrixT = 5;
        public const int nNpc =10;
        public const int nMaxNpc = 20;
        public int cont=0;

        public static void Main(string[] args)
        {
            NpcFactory factory = new NpcFactory();
            Movimientos mov = new Movimientos();

            Npc[,] npcArray = factory.GenerarMatrix(size: matrixT); //Genera una matriz del tamaño de matrixT

            factory.GenerarNpcs(npcArray, nNpc); // Genera 4 NPCs genéricos
            factory.GenerarSmith(npcArray);   // Genera 1 Smith
            factory.GenerarNeo(npcArray);     // Genera 1 Neo 

            Matrix matrixInstance = new Matrix(matrixT);
            matrixInstance.MatrixArray = npcArray;



            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("Turno nº"+i);

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
                        matrixInstance.MovimientoSmith();
                        matrixInstance.DisplayMatrix();
                        matrixInstance.MovimientoNpc();
                        matrixInstance.DisplayNpc();
                        break;
                    case 10:
                    case 20:
                        matrixInstance.MovimientoNeo();
                        matrixInstance.MovimientoSmith();
                        matrixInstance.DisplayMatrix();
                        matrixInstance.MovimientoNpc();
                        matrixInstance.DisplayNpc();
                        break;
                    case 5:
                    case 15:
                        matrixInstance.MovimientoNeo();
                        matrixInstance.DisplayMatrix();
                        matrixInstance.MovimientoNpc();
                        matrixInstance.DisplayNpc();
                        break;

                    default:
                        matrixInstance.DisplayMatrix();
                        matrixInstance.MovimientoNpc();
                        matrixInstance.DisplayNpc();
                        break;
                }
            }


        }
    }
}