using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag23
{
    class Program
    {
        static void Main(string[] args)
        {
            Game3 game = new Game3(1, 2, 3, 4, 5, 6, 7, 8, 0);

            while (game.VerificationOfWinner() == false)
            {
                Console.Clear();
                Console.WriteLine("Игра началась!\n");
                Print.Prints(game);
                Console.Write("Введите число, стоящее рядом с нулем,чтобы поменять их местами: ");
                int value = Convert.ToInt32(Console.ReadLine());
                game.GetLocation(value);
                game.Shift(value);
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}