using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tag23
{
    class Game2 : Game
    {
        public Game2(params int[] field) : base(field)
        {
            Randomize();
        }
        protected void Randomize()
        {
            int help = 0;
            Random gen = new Random();
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    help = gen.Next(0, field.Length);
                    for (int k = 0; k < field.Length; k++)
                    {
                        while ((field[help] == field[k]) && (field[help] == -1))
                        {
                            help = gen.Next(0, field.Length);
                        }
                    }
                    gameField[i, j] = field[help];
                    field[help] = -1;
                }
            }
        }
        public bool VerificationOfWinner()
        {
            int count = 1;
            int c = 0;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == count)
                    {
                        c++;
                    }
                    count++;
                }
            }
            if (c == field.Length - 1 && (gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1] == 0))
            {
                Console.WriteLine("Вы выиграли!");
                return true;
            }
            else return false;
        }
    }
}