/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Programming Assignment 4 - Arrays (Wood Chuck)
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

namespace PROG110_WoodChuck
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarations
            int inputChucks = 0;
            int inputDays = 0;
            int woodValue = 0;
            int simulationAttempt = 0;

            float totalWood = 0;
            float avgWood = 0;

            string tryAgain = "Y";

            const int MAX_DAYS = 10;
            const int MAX_CHUCKS = 100;

            WriteLine("******** ACME Industries Simulation Division ********" +
                    "\n*                                                   *" +
                    "\n*    Woodchuck Wood Chucking Simulation v. 1.0      *" +
                    "\n*                                                   *" +
                    "\n*    One row per woodchuck, one column per day      *" +
                    "\n*                                                   *" +
                    "\n*****************************************************");

            do
            {
                //Clears data
                inputChucks = 0;
                inputDays = 0;
                woodValue = 0;
                totalWood = 0;
                avgWood = 0;
                simulationAttempt++;
                //Ask user for input that is within parameter
                WriteLine("*\t*\t*");
                Write("How many woodchucks would" +
                    " you like to simulate? (1-100): ");
                while (!int.TryParse(ReadLine(), out inputChucks) || inputChucks < 1 || inputChucks > MAX_CHUCKS)
                {
                    Write("How many woodchucks would" +
                        " you like to simulate? (1-100): ");
                }
                Write("How many days would" +
                    " you like to simulate? (1-10): ");
                while ((!int.TryParse(ReadLine(), out inputDays) || inputDays < 1 || inputDays > MAX_DAYS))
                {
                    Write("How many days would" +
                        " you like to simulate? (1-10): ");
                }

                //Establish wood Array
                int[,] wood = new int[inputChucks, inputDays];
                Random rand = new Random();

                //Print title of simulation currently being performed
                Write($"SIMULATION {simulationAttempt}: {inputChucks}" +
                    $" woodchucks over {inputDays} days\n");

                //Randomly generates total woods chucked for a day
                for (int c = 0; c < inputChucks; c++)
                {
                    for (int d = 0; d < inputDays; d++)
                    {
                        wood[c, d] = rand.Next(1, 101);
                    }
                }

                //Prints Column header
                Write("     ");
                for (int i = 1; i <= inputDays; i++)
                {
                    Write(String.Format("{0,7}", i)); //Digit
                }

                Write("\n     ");
                for (int i = 1; i <= inputDays; i++)
                {
                    Write(String.Format("{0,7}", "____")); //Line seperator
                }

                //Prints rows and data within row
                for (int row = 0; row < inputChucks; row++)
                {
                    WriteLine("\n");
                    Write(String.Format("{0,3} |", row + 1));
                    for (int column = 0; column < inputDays; column++)
                    {
                        woodValue = wood[row, column];
                        Write(String.Format("{0,7}", woodValue));
                    }
                }

                //Calculations for Final Print
                foreach (int x in wood)
                {
                    totalWood = totalWood + x;
                }
                avgWood = totalWood / (inputDays * inputChucks);

                //Final Print
                Write($"\nTotal wood chucked:\t{totalWood:n0}");
                Write($"\nAverage woodchuck chucked:\t{avgWood:n2}");

                Write("\nTo run another simulation, enter \"Y\": ");
                tryAgain = ReadLine().ToUpper();
            } while (tryAgain == "Y");

            //End of program
            WriteLine("\nPress any key....");
            ReadKey();
        }
    }
}