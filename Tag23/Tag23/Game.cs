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
        }
        
        // Индексатор
        public int this[int i, int j]
        {
            get
            {
                return gameField[i, j];
            }
        }

        private void CreateFieldOfGame()
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

        public virtual void Shift(int value)
        {
            int[,] helpmas = new int[1, 1];
            int[] coordinateValue = GetLocation(value);
            int[] coordinateZero = GetLocation(0);

            if ((Math.Abs(coordinateValue[0] - coordinateZero[0]) == 1 && coordinateValue[1] == coordinateZero[1]) ||
                ((Math.Abs(coordinateValue[1] - coordinateZero[1]) == 1 && coordinateValue[0] == coordinateZero[0])))
            {
                int temp = 0;
                temp = gameField[coordinateValue[0], coordinateValue[1]];
                gameField[coordinateValue[0], coordinateValue[1]] = gameField[coordinateZero[0], coordinateZero[1]];
                gameField[coordinateZero[0], coordinateZero[1]] = temp;
            }
        }
        public int[,] ReturnGameField()
        {
            return gameField;
        }
    }
}