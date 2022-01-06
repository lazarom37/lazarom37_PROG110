/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Programming Assignment 4 - Arrays (Dice Simulator)
*    
*    Description: 
*    This is a program for the Arrays assignment meant to demonstrate
*    understanding of two-dimensional arrays in C#
* 
*    Revision    Date               Release Comment 
*    --------     ----------        ------------------------------------------------------ 
*    1.0         11/21/2021         Initial Release 
* 
*/

using System;
using System.Linq;
using static System.Console;

namespace PROG110_DiceRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarations
            int[] sums = new int[13];

            int sum = 0;
            int dice01 = 0;
            int dice02 = 0;
            int desiredRolls = 0;
            int rolls = 0;
            string tryAgain = "Y";

            // Welcome Banner
            WriteLine("******** ACME Industries Simulation Division ********" +
                "\n*                                                   *" +
                "\n*          Dice Rolling Simulation v. 1.0           *" +
                "\n*                                                   *" +
                "\n*       One row per possible roll of two dice       *" +
                "\n*                                                   *" +
                "\n*****************************************************");

            do
            {
                //Clears data
                Array.Clear(sums, 0, sums.Length);

                Write("\nHow many rolls would you like to simulate? >> ");
                desiredRolls = Convert.ToInt32(ReadLine());
                if (desiredRolls < 0 || desiredRolls > 100000 )
                {
                    desiredRolls = 100000;
                }

                //Dice
                Random rand = new Random();
                for (int i = 0; i < desiredRolls; i++)
                {
                    dice01 = rand.Next(1, 7);
                    dice02 = rand.Next(1, 7);

                    sum = dice01 + dice02;
                    sums[sum] += 1;
                }

                WriteLine("Roll" + "\tCount");

                //Writes data underneath Roll and Count labels
                for (int i = 2; i <= 12; i++)
                {
                    WriteLine(i + "\t{0}", sums[i]);
                }

                foreach (int x in sums)
                {
                    rolls = (rolls + x);
                }

                WriteLine("\t" + rolls);
                WriteLine("\nTo run another simulation, enter \"Y\"");
                tryAgain = ReadLine().ToUpper();
            } while (tryAgain == "Y");

            //End of program
            WriteLine("\nPress any key....");
            ReadKey();
        }
    }
}