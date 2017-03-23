using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tag23
{
    class Game3 : Game2
    {
        public readonly List<int[]> stepsPlayer;
        public int[] help;

        public Game3(params int[] values)
        {
            CreateFieldOfGame();
            Randomize();
            stepsPlayer = new List<int[]>();

        }
        public override void Shift(int value)
        {
            int[] coordinatesZero = GetLocation(0);
            int[] massiveMoveValue = GetLocation(value);

            stepsPlayer.Add(coordinatesZero);
            stepsPlayer.Add(massiveMoveValue);

            help = new[] { coordinatesZero[0], coordinatesZero[1], massiveMoveValue[0], massiveMoveValue[1] };
        }

        public int[] returnHelp()
        {
            return help;
        }
    }
}