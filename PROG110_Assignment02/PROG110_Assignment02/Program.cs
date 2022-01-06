using System;
using static System.Console;

namespace PROG110_Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            int winningNumber;
            int guess;
            bool infinite = true;


            Random r = new Random();
            winningNumber = r.Next(1, 5);
            do
            {

            } while infinite = true;
            if (guess == winningNumber)
            {
                if (guess < 1 || guess > 5)
                {
                    WriteLine("INVALID");
                }
                else if (guess == winningNumber)
                {
                    WriteLine("WINRAR");
                }
                else
                {
                    WriteLine("WRONG");
                }
            }
        }
    }
}