using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tag23
{
    class Game3 : Game2
    {
        public readonly List<int> stepsPlayer;
        public int[] help;

        public Game3(params int[] field) : base(field)
        {       
            stepsPlayer = new List<int>();

        }
        public override void Shift(int value)
        {
            base.Shift(value);
            stepsPlayer.Add(value);
        }
        public void Rollback()
        {
            int lastStep = stepsPlayer.Last();
            stepsPlayer.Remove(lastStep);
            this.Shift(lastStep);
        }
       
    }
}