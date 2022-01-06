/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Phil Duncan
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Hello Again Quiz
*    
*    Description:   
*    This is for a timed graded excercise
*    
*    
*    
* 
*    Revision    Date               Release Comment 
*    --------     ----------        ------------------------------------------------------ 
*    1.0         10/10/2021         Initial Release 
*    1
* 
*/
using System;
using static System.Console;

namespace PROG110___Hello_Again
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int nameLength;
            double taxRate;
            decimal taxTotal;
            decimal TenBucks = 10.0m;
            Console.WriteLine("What is your name?");
            name = ReadLine();
            nameLength = name.Length;
            Console.WriteLine("Hello {0}! Did you realize that your name contains {1} characters?", name, nameLength);
            Console.WriteLine("Enter a possible sales tax rate: ");
            taxRate = double.Parse(ReadLine());
            taxTotal = ((decimal)taxRate * TenBucks) / 100;
            Console.WriteLine("At that rate, tax on $10.00 would be {0}", taxTotal);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
