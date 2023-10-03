using System;
namespace matrix
{
    public class Metodos
    {
        public class Metodos()
        {
            public void MoveSmithTo(int currentX, int currentY, int newX, int newY)
            {
                if (_matrixArray[currentX, currentY] is Smith && _matrixArray[newX, newY] is Npc)
                {
                    Npc temp = _matrixArray[newX, newY];
                    _matrixArray[newX, newY] = _matrixArray[currentX, currentY];
                    _matrixArray[currentX, currentY] = temp;

                    Console.WriteLine($"Smith ha sido movido a [{newX}, {newY}] e intercambiado con {_matrixArray[currentX, currentY].GetType().Name}.");
                }
                else if (_matrixArray[currentX, currentY] is Smith)
                {
                    _matrixArray[newX, newY] = _matrixArray[currentX, currentY];
                    _matrixArray[currentX, currentY] = null;

                    Console.WriteLine($"Smith ha sido movido a [{newX}, {newY}] y la posición anterior está ahora vacía.");
                }
                else
                {
                    Console.WriteLine("Operación no válida: La posición inicial no contiene a Smith o la posición objetivo no es válida.");
                }
            }
        }
    }
}
