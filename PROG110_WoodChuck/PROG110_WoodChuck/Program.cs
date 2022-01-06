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
*    1.1         12/12/2021         Updated and refactored into methods as requested
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
            Random rand = new Random();

            PrintSessionBanner();
            int[,] array = RunSimulation(rand);
            PrintMatrix(array);
            PrintSummary(array);

            WriteLine("\nPress any key to wrap up....");
            ReadKey();

        }
        private static void PrintSessionBanner()
        {
            WriteLine("******** ACME Industries Simulation Division ********" +
        "\n*                                                   *" +
        "\n*    Woodchuck Wood Chucking Simulation v. 1.0      *" +
        "\n*                                                   *" +
        "\n*    One row per woodchuck, one column per day      *" +
        "\n*                                                   *" +
        "\n*****************************************************");
        }

        private static int GetSimulatorParameter(string prompt, int min, int max)
        {
            int input;
            Write(prompt);
            while (!int.TryParse(ReadLine(), out input) || input < min || input > max)
            {
                Write($"ERROR: Please enter a number between {min} and {max}");
            }
            return input;
        }

        private static int[,] RunSimulation(Random rand)
        {
            int inputChucks = GetSimulatorParameter("How many woodchucks" +
                " would you like to simulate? (1-100): ", 1, 100);
            int inputDays = GetSimulatorParameter("How many days would" +
                " you like to simulate? (1-10): ", 1, 10);

            int[,] array = new int[inputChucks, inputDays];

            //Randomly generates total woods chucked for a day
            for (int c = 0; c < inputChucks; c++)
            {
                for (int d = 0; d < inputDays; d++)
                {
                    array[c, d] = rand.Next(1, 101);
                }
            }
            return array;
        }
        private static void PrintMatrix(int[,] array)
        {
            int col;
            int row;

            //Prints Column header
            Write("     ");
            for (col = 0; col < array.GetLength(0); col++)
            {
                Write(String.Format("{0,7}", col+1));
            }

            Write("\n     ");
            for (col = 0; col < array.GetLength(1); col++)
            {
                Write(String.Format("{0,7}", "____")); //Line seperator
            }

            //Prints rows and data within row
            for (row = 0; row < array.GetLength(0); row++)
            {
                WriteLine("\n");
                Write(String.Format("{0,3} |", row + 1));   //Row number
                for (col = 0; col < array.GetLength(1); col++)
                {
                    Write(String.Format("{0,7}", array[row, col]));   //Data
                }
            }

        }
        private static void PrintSummary(int[,] array)
        {
            float totalWood = 0;
            float avgWood = 0;

            //Calculations for Final Print
            foreach (int x in array)
            {
                totalWood = totalWood + x;
            }
            avgWood = totalWood / (array.GetLength(1) * array.GetLength(1));

            //Final Print

            WriteLine($"\n\nTotal wood chucked:\t\t{totalWood,10:N0}");
            WriteLine($"Average woodchuck chucked:\t{avgWood,10:N}");
        }
    }
}