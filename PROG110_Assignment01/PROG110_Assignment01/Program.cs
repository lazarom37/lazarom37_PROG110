/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Programming Assignment 1 - Data
*    
*    Description: 
*    This is a program for customers of Acme Anvils Corporation
*    to use to make orders of Warner Bros. cartoon anvils for gags
*    as well as output an invoice explaining the cost, shipping,
*    and a proper end-program message
* 
*    Revision    Date               Release Comment 
*    --------     ----------        ------------------------------------------------------ 
*    1.0         10/10/2021         Initial Release 
*
* 
*/
using System;
using static System.Console;

namespace PROG110_Assignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            const decimal anvilPrice = 78.50m;
            const double taxRate = 0.095;
            string fullName;
            string StreetAdress;
            string City;
            string State;
            string ZipCode;
            int anvil;
            double subTotal;
            double grandTotal;
            double taxTotal;

            //Introduction, asks for how many anvils desired
            Console.WriteLine("Welcome! \nAcme Anvils Corporation,\nSupporting the animation industry since 1949!!");
            Console.WriteLine("Hello, I'm Marcus Lazaro! How many anvils are you ordering?");
            anvil = int.Parse(ReadLine());
            subTotal = anvil * (int)anvilPrice;
            taxTotal = (subTotal * taxRate);
            grandTotal = subTotal + taxTotal;

            //Asks for address and name
            Console.WriteLine("I can certainly help you with your order. What is your name and Address? \nName:");
            fullName = ReadLine();
            Console.WriteLine("Street Address: ");
            StreetAdress = ReadLine();
            Console.WriteLine("City: ");
            City = ReadLine();
            Console.WriteLine("State (Please use TWO (2) letters): ");
            State = ReadLine();
            Console.WriteLine("Zip Code: ");
            ZipCode = ReadLine();
            
            //Prints out invoice
            Console.WriteLine("\nPress any key to display invoice...\n*******************************");
            ReadKey();
            Console.WriteLine("***ACME Anvils Corporation***\nCustomer Invoice\n\nSHIP TO:");
            Console.WriteLine("\t{0}", fullName);
            Console.WriteLine("\t{0}", StreetAdress);
            Console.WriteLine("\t{0}", City);
            Console.WriteLine("\t{0}", State);
            Console.WriteLine("\t{0}", ZipCode);
            Console.WriteLine();

            Console.WriteLine("Quantity order: {0}\t", anvil);
            Console.WriteLine("Cost per anvil {0}\t", anvilPrice);
            Console.WriteLine("Subtotal: {0}\t", subTotal.ToString("C"));
            Console.WriteLine("Sales Tax: {0}\t", taxTotal.ToString("C"));
            Console.WriteLine("_________");
            Console.WriteLine("TOTAL: {0}\t", grandTotal.ToString("C"));
            Console.WriteLine("*********************************");
            //Thank-you ending
            Console.WriteLine("Your total today is {0}. Thanks for shopping with Acme!\nAnd don't forget: Acme anvils fly farther, drop faster, and land harder than any other anvil on the Market!", grandTotal);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}