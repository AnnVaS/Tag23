using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag23
{
    class Game
    {
        protected int[] field;
        public readonly int[,] gameField;
        private int moveX;
        private int moveY;

        public Game(params int[] field)
        {
            this.field = field;
            gameField = new int[Convert.ToInt32(Math.Sqrt(field.Length)), Convert.ToInt32(Math.Sqrt(field.Length))];
            CreateFieldOfGame();
            //GenerationField();
        }

        // Индексатор
        public int this[int i, int j]
        {
            get { return gameField[i, j]; }
        }

        protected void CreateFieldOfGame()
        {
            int sizeOfField = Convert.ToInt32(Math.Sqrt(field.Length));
            {
                int helpCount = 0;
                for (int i = 0; i < sizeOfField; i++)
                {
                    for (int j = 0; j < sizeOfField; j++)
                    {
                        if (helpCount <= field.Length - 1)
                        {
                            gameField[i, j] = field[helpCount];
                            if (gameField[i, j] >= 0)
                            {
                                gameField[i, j] = field[helpCount];
                                helpCount++;
                            }
                            else throw new Exception("Есть отрицательные элементы в массиве");
                        }
                    }
                }
            }
        }

        public int[] GetLocation(int value)
        {
            int[] helpmas = new int[2];
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (value == gameField[i, j])
                    {
                        helpmas[0] = i;
                        helpmas[1] = j;
                    }
                }
            }
            return helpmas;
        }

        public void Shift(int value)
        {
            int[,] helpmas = new int[1, 1];
            int coordinateXZero = 0;
            int coordinateYZero = 0;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 0)
                    {
                        coordinateXZero = i;
                        coordinateYZero = j;
                    }
                }
            }
            if (Math.Abs(moveX - coordinateXZero) == 1 && moveY == coordinateYZero)
            {
                helpmas[0, 0] = gameField[moveX, moveY];
                gameField[moveX, moveY] = gameField[coordinateXZero, coordinateYZero];
                gameField[coordinateXZero, coordinateYZero] = helpmas[0, 0];
            }
            if (Math.Abs(moveY - coordinateYZero) == 1 && moveX == coordinateXZero)
            {
                helpmas[0, 0] = gameField[moveX, moveY];
                gameField[moveX, moveY] = gameField[coordinateXZero, coordinateYZero];
                gameField[coordinateXZero, coordinateYZero] = helpmas[0, 0];
            }
        }
    }
}