/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Programming Assignment 3 - Loops
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
*    1.1         10/16/2021         Update for Assignment 2, includes new 
*                                   taxRate and checking for Futility Club
*                                   membership
*    1.2         10/24/2021         Update for Assignment 3, includes new
*                                   taxRate, shipping costs, price changes,
*                                   change in Futility Club reward, 
* 
*/
using System;
using System.Linq;
using static System.Console;

namespace PROG110_Assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable declarations
            const decimal SHIPPING_PER_ANVIL = 99m;
            const decimal TAXRATE = 0.0995m;

            char choice;

            int anvil;
            int winningNumber;
            int guess;

            string fullName;
            string streetAddress;
            string city;
            string State;
            string zipCode;
            string freeItem = "Nuthin";

            string[] listOfStates = new string[] { "AK", "AZ", "CA", "CO", "NM", "OR", "UT", "WA" };// Declare array and set valid state codes to following.

            decimal anvilPrice = 67.99m;
            decimal subTotal;
            decimal subTotalInitial;
            decimal grandTotal = 0.0m;
            decimal taxTotal;
            decimal taxableAmount = 0.0m;
            decimal shippingCost;
            decimal discountTotal = 0.0m;

            bool repeatOrder = true;
            bool wonPrize = false;
            bool countdown;
            while (repeatOrder == true)
            {
                //Section 1.A - Countdown Provision
                do
                {
                    WriteLine("Countdown to Order");
                    for (int i = 3; i >= 1; i--)
                    {
                        WriteLine($"{i}...");
                        System.Threading.Thread.Sleep(1000);
                    }
                    countdown = false;
                } while (countdown == true);

                //Section 1.B - Making Order, asks for desired amount of anvils
                WriteLine("\a******************Welcome to Acme Anvils " +
                          "Corporation******************");
                WriteLine("Supporting the animation industry " +
                          "for 70 years and counting!!");

                WriteLine("Hello, I'm Marcus Lazaro!" +
                    " How many anvils are you ordering?");

                //Section 1.C - Ordering the anvils
                Write("Number of Anvil(s): ");
                anvil = int.Parse(ReadLine());
                if (anvil <= 0)
                {
                    do
                    {
                        WriteLine("ERROR: Number of anvils must be" +
                            " a positive, whole number.");
                        Write("Please Try Again: ");
                        anvil = int.Parse(ReadLine());
                    } while (anvil <= 0);
                }

                //Section 2 - Making order
                //2.A Ask for user's Name
                WriteLine("I can certainly help you with your order." +
                    " What is your name and Address?");
                Write("Name: ");
                fullName = ReadLine();
                if (string.IsNullOrEmpty(fullName))
                {
                    do
                    {
                        WriteLine("ERROR: Customer name is required");
                        Write("Please Try Again: ");
                        fullName = ReadLine();
                    } while (string.IsNullOrEmpty(fullName));
                }
                //2.B Ask for user's Street Address
                Write("Street Address: ");
                streetAddress = ReadLine();
                //2.C Ask for user's City
                Write("City: ");
                city = ReadLine();
                //2.D Ask for user's State
                Write("State (Please use TWO (2) letters): ");
                State = ReadLine().ToUpper();
                while (!listOfStates.Any(State.Contains))
                {
                    WriteLine($"ERROR: We do not ship to {State}");
                    WriteLine("Valid state codes are: AK, CA, CO," +
                              " NM, OR, UT, WA");
                    Write("Please enter a valid state: ");
                    State = ReadLine().ToUpper();
                }
                Write("Zip Code: ");
                zipCode = ReadLine();
                if (zipCode.Length != 5)
                {
                    do
                    {
                        Write("ERROR: Zip code must be 5 characters long." +
                              "Please Try Again: ");
                        zipCode = ReadLine();
                    } while (zipCode.Length != 5);
                }

                //Section 3 - Membership Check
                Write("Are you a member of our Futility" +
                    "Club frequent shopper program (Y/N)  ");
                choice = char.ToUpper(char.Parse(ReadLine()));

                if (choice == 'Y')
                {
                    Write("Excellent! You’ll receive " +
                          "an AMAZING 15% discount" +
                          "\non today’s purchase!");
                    Write("What’s more, as a valued" +
                          "\nmember of our loyalty program, " +
                          "you’ll have a chance" +
                          "\nto win a bonus gift in our " +
                          "exciting Members - Only Gallon" +
                          "\nof invisible paint contest! " +
                          "Pick a number between 1 and 5!  ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    Random r = new Random();
                    winningNumber = r.Next(1, 5);

                    if (guess < 1 || guess > 5)     //User inputs something out of bounds
                    {
                        WriteLine("That’s not a number between 1 and 5. " +
                            "What \n ultra-maroon!" +
                            "Still, we value your loyalty.");
                    }
                    else if (guess == winningNumber)        //User guesses correctly
                    {
                        WriteLine("Woo hoo! You guessed the secret " +
                            "number: {0}. " +
                            "\n A gallon of ACME " +
                            "Invisible Paint is headed " +
                            "your way!", winningNumber);
                        freeItem = "CAN OF INVISIBLE PAINT";
                        wonPrize = true;
                    }
                    else if (guess != winningNumber)        //User incorrectly guesses
                    {
                        WriteLine("Aww, too bad.  You guessed {0}," +
                            "\n but the secret number was {1}. " +
                            "\n No paint. What a" +
                            " loser. Very sad.", guess, winningNumber);
                    }
                }
                else
                {
                    WriteLine("What’s wrong with you? " +
                        "That just cost you a 15% discount" +
                        "\nand an opportunity to win a" +
                        " gallon of invisible paint. Sad.");
                }
                //Section 4 - Calculations
                //4.A - SettingAnvil Pricing
                if (anvil >= 1 && anvil <= 9)
                {
                    anvilPrice = 80.00m;
                }
                else if (anvil >= 10 && anvil <= 19)
                {
                    anvilPrice = 72.35m;
                }
                //4.B - Intializing Calculations
                subTotal = anvil * (int)anvilPrice;
                subTotalInitial = subTotal;
                if (choice == 'Y')      //Executes if user is a member
                {
                    discountTotal = subTotal * (decimal)0.15;
                    taxableAmount = subTotal - discountTotal;
                    subTotal = taxableAmount;
                }
                //4.C - Finalized Calculations
                taxTotal = subTotal * TAXRATE;
                shippingCost = (anvil * SHIPPING_PER_ANVIL);
                grandTotal = subTotal + taxTotal + shippingCost;

                //Section 5.A - Invoice, Shipping Information
                WriteLine("\nPress any key to display invoice..." +
                    "\n*******************************");
                ReadKey();
                WriteLine("***ACME Anvils Corporation***" +
                    "\nCustomer Invoice\n\nSHIP TO:");
                WriteLine("\t{0}", fullName);
                WriteLine("\t{0}", streetAddress);
                WriteLine("\t{0}", city);
                WriteLine("\t{0}", State);
                WriteLine("\t{0}", zipCode);
                WriteLine();
                //Section 5.B - Transactions
                WriteLine("{0,-22}{1,15}", "Quantity:", anvil);
                WriteLine("{0,-22}{1,15:C}", "Cost per anvil:", anvilPrice);
                WriteLine("{0,-22}{1,15:C}", "Subtotal:", subTotalInitial);
                if (choice == 'Y')  //Prints if user is part of Futility club
                {
                    WriteLine("{0,-22}{1,15:C}", "Less 15% Futility Club:",
                        -discountTotal);
                    WriteLine("{0,-22}{1,15:C}", "Taxable Amount:",
                        taxableAmount);
                }
                //Section 5.B - Transactions (Continued)
                WriteLine("{0,-22}{1,15:C}", "Sales Tax:", taxTotal);
                WriteLine("{0,-22}{1,15:C}", "Shipping:", shippingCost);
                WriteLine("\t_________");
                WriteLine("\n{0,-22}{1,15:C}", "TOTAL:", grandTotal);
                if (wonPrize == true)
                {
                    WriteLine("BONUS: Along with today's order, you'll " +
                        "receive a FREE {0}", freeItem);
                }
                WriteLine("*********************************");

                //Section 6.A - Wrap Up
                WriteLine("Your total today is {0:C}." +
                    " Thanks for shopping with Acme!" +
                    "\nAnd don't forget: Acme" +
                    "anvils fly farther, drop faster," +
                    "\nand land harder than any other" +
                    " anvil on the Market!", grandTotal);

                //Section 6.B - Making another order
                Write("Ready to take another order? (Y/N)    ");
                choice = char.ToUpper(char.Parse(ReadLine()));
                if (choice == 'Y')
                {
                    countdown = true;
                } else {
                    repeatOrder = false;
                    WriteLine("Thank you for your patronage " +
                        "today. We hope to see you again!");
                }
            }
            WriteLine("\nEnd of Program. Press any key to continue...");
            ReadKey();
        }
    }
}