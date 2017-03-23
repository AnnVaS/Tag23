using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag23
{
    static class Print
    {
        public static void Prints(Game game)
        {
            int[,] gameField = game.ReturnGameField();
            Console.Clear();
            for (int i = 0; i < game.gameField.GetLength(0); i++)
            {
                for (int j = 0; j < game.gameField.GetLength(1); j++)
                {
                    if (j != game.gameField.GetLength(0) - 1)
                    {
                        Console.Write(game.gameField[i, j] + " ");
                    }
                    else Console.Write(game.gameField[i, j] + "\n\n");
                }
            }
            Console.WriteLine();
        }
    }
}