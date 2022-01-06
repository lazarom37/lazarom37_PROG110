/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Timed Graded Exercise: SumItUp with Methods
*    
*    Description: 
*    This excercise assignment was made to reinforce my understanding of passing an array to a method
* 
*    Revision    Date               Release Comment 
*    --------     ----------        ------------------------------------------------------ 
*    1.0         12/5/2021         Initial Release 

* 
*/

using System;
using System.Linq;
using static System.Console;

namespace PROG110_Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] someNumbers = new int[]
            { 1, 2, 3, 4, 5 };
            WriteLine($"First array: {SumItUp(someNumbers)}");
            WriteLine($"Second array: {SumItUp(new int[] { 10, 20, 30 })}");

            Write("Press any key to end program...");
            ReadKey();
        }
        private static int SumItUp(int[] someNumbers)
        {
            int sum = 0;
            someNumbers.Reverse();
            for (int i = 0; i < someNumbers.Count(); i++)
            {
                sum = sum + someNumbers[i];
            }
            return sum;
        }
    }
}