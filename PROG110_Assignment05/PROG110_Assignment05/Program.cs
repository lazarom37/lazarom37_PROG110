/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: Programming Assignment 5 - Methods
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
*    1.3         11/27/2021         Updated for Assignment 5, includes
*                                   implementation of methods for several
*                                   sections seperated from Main()
* 
*/
using System;
using static System.Console;

namespace PROG110_Assignment05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Section 0.A - Declarations
            char choice;

            int anvil;

            string fullName;
            string streetAddress;
            string city;
            string State;
            string zipCode;

            string[] listOfStates = new string[]
            { "AK", "AZ", "CA", "CO", "NM", "OR", "UT", "WA" };
  
            bool repeatOrder = true;
            bool wonPrize = false;
            bool isMember = false;
            do
            {
                //Section 1.A - Countdown Provision
                Countdown(3);

                //Section 1.B - Making Order, asks for desired amount of anvils
                PrintBanner();
                WriteLine("Hello, I'm Marcus Lazaro!" +
                    " How many anvils are you ordering?");

                //Section 1.C - Ordering the anvils
                Write("Number of Anvil(s): ");
                anvil = GetPositiveInt(ReadLine());

                //Section 2.A - Ask for customer's information
                WriteLine("I can certainly help you with your order." +
                    " What is your name and Address?");
                Write("Name: ");
                fullName = GetValidString(ReadLine(), 1);
                Write("Street Address: ");
                streetAddress = GetValidString(ReadLine(), 1);
                Write("City: ");
                city = GetValidString(ReadLine(), 1, 20);
                Write("State (Please use TWO (2) letters): ");
                State = GetValidState(ReadLine(), listOfStates);
                Write("Zip Code: ");
                zipCode = GetValidString(ReadLine(), 5, 5);

                //Section 3 - Membership Check
                if (LoyaltyDiscount() == true)
                {
                    isMember = true;
                    if (EnterContest() == true)
                    {
                        wonPrize = true;
                    }
                }

                //Section 4.A - Invoice, Shipping Information
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

                //Section 4.B - Prints Receipt + Wrap-Up
                WriteLine("Your total today is {0:C}." +
                    " Thanks for shopping with Acme!" +
                    "\nAnd don't forget: Acme" +
                    "anvils fly farther, drop faster," +
                    "\nand land harder than any other" +
                    " anvil on the Market!", CalcAndPrintInvoiceBody(anvil, isMember, wonPrize));

                //Section 5.A - Making another order
                Write("Ready to take another order? (Y/N)    ");
                choice = char.ToUpper(char.Parse(ReadLine()));
                if (choice == 'N')
                {
                    repeatOrder = false;
                    WriteLine("Thank you for your patronage " +
                              "today. We hope to see you again!");
                }
            } while (repeatOrder == true);
            WriteLine("\nEnd of Program. Press any key to continue...");
            ReadKey();
        }

        //Methods Section

        private static void PrintBanner()
        {
            WriteLine("\a******************Welcome to Acme Anvils " +
          "Corporation******************");
            WriteLine("Supporting the animation industry " +
                      "for 70 years and counting!!");
        } 
        private static void Countdown(int numberOfSeconds)
        {
            bool countdown;
            do
            {
                WriteLine("Countdown to Order");
                for (int i = numberOfSeconds; i >= 1; i--)
                {
                    WriteLine($"{i}...");
                    System.Threading.Thread.Sleep(1000);
                }
                countdown = false;
            } while (countdown == true);
        } 
        private static int GetPositiveInt(string prompt)
        {
            int validAnvilOrder = 0;
            Int32.TryParse(prompt, out validAnvilOrder);
            while (validAnvilOrder <= 0)
            {
                WriteLine("ERROR: Number of anvils must be" +
                    " a positive, whole number.");
                Write("Please Try Again: ");
                validAnvilOrder = int.Parse(ReadLine());
            }
            return validAnvilOrder;
        } 
        private static string GetValidString(string prompt, int min)
        {
            int promptStringLength = prompt.Length;
            while (promptStringLength < min)
            {
                Write("Name must be at least 1 character(s) long." +
                    " Please re-enter.  ");
                prompt = ReadLine();
                promptStringLength = prompt.Length;
            }

            return prompt;
        }
        private static string GetValidString(string prompt, int min, int max)
        {
            int promptStringLength = prompt.Length;
            while (promptStringLength < 1)
            {
                Write("Name must be at least 1 character(s) long." +
                    " Please re-enter.  ");
                prompt = ReadLine();
                promptStringLength = prompt.Length;
            }
            if (min == 1 && max == 20)
            {
                while (promptStringLength < 1 || promptStringLength > 20)
                {
                    Write("City must be at between 1 and 20 characters long." +
                        " Please re-enter.  ");
                    prompt = ReadLine();
                    promptStringLength = prompt.Length;
                }
            }
            if (min == 5 && max == 5)
            {
                while (promptStringLength != 5)
                {
                    Write("Zip must be exactly 5 characters long." +
                        " Please re-enter:  ");
                    prompt = ReadLine();
                    promptStringLength = prompt.Length;
                }
            }
            if (min == 2 && max == 2)
            {
                while (promptStringLength != 2)
                {
                    Write("Please enter a valid state (2 characters):  ");
                    prompt = ReadLine();
                    promptStringLength = prompt.Length;
                }
            }

            return prompt;
        } 
        private static string GetValidState(string prompt, string[] sortedStateArray)
        {
            bool endLoop = false;
            bool invalidInput = true;
            GetValidString(prompt, 2, 2);
            do
            {
                for (int i = 0; i < 8; i++)
                {
                    if (sortedStateArray[i].ToUpper() == prompt.ToUpper())
                    {
                        endLoop = true;
                        invalidInput = false;
                    }
                }
                if (invalidInput == true)
                {
                    Write("Please enter a valid state" +
                        " (AK, AZ, CA, CO, NM, OR, UT, WA):  ");
                    prompt = ReadLine();
                }
            } while (endLoop == false);
            return prompt;
        } 
        private static bool LoyaltyDiscount()
        {
            char choice;
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
                      "Pick a number between 1 and 10!  ");
                return true;
            }
            else
            {
                WriteLine("What’s wrong with you? " +
                    "That just cost you a 15% discount" +
                    "\nand an opportunity to win a" +
                    " gallon of invisible paint. Sad.");
                return false;
            }
        } 
        private static bool EnterContest()
        {
            int winningNumber;
            int guess;
            guess = Convert.ToInt32(Console.ReadLine());
            Random chanceGenerator = new Random();
            winningNumber = chanceGenerator.Next(1, 10);

            if (guess < 1 || guess > 10)   //User inputs something out of bounds
            {
                WriteLine("That’s not a number between 1 and 5. " +
                    "What \n ultra-maroon!" +
                    "Still, we value your loyalty.");
                return false;
            }
            else if (guess == winningNumber)        //User guesses correctly
            {
                WriteLine("Woo hoo! You guessed the secret " +
                    "number: {0}. " +
                    "\n A gallon of ACME " +
                    "Invisible Paint is headed " +
                    "your way!", winningNumber);
                return true;
            }
            else if (guess != winningNumber)        //User incorrectly guesses
            {
                WriteLine("Aww, too bad.  You guessed {0}," +
                    "\n but the secret number was {1}. " +
                    "\n No paint. What a" +
                    " loser. Very sad.", guess, winningNumber);
            }
            return false;
        } 
        private static decimal CalcAndPrintInvoiceBody
            (int qty, bool discount, bool promotionPrize)
        {
            //Section 0.A - Declarations
            const decimal SHIPPING_PER_ANVIL = 99m;
            const decimal TAXRATE = 0.0995m;

            string freeItem = "Can of Invisible Ink";

            decimal anvilPrice = GetAnvilPrice(qty);
            decimal subTotal;
            decimal subTotalInitial;
            decimal grandTotal = 0.0m;
            decimal taxTotal;
            decimal taxableAmount = 0.0m;
            decimal shippingCost;
            decimal discountTotal = 0.0m;

            //Section 1.A - Intializing Calculations
            subTotal = qty * (int)anvilPrice;
            subTotalInitial = subTotal;
            if (discount == true)
            {
                discountTotal = subTotal * (decimal)0.15;
                taxableAmount = subTotal - discountTotal;
                subTotal = taxableAmount;
            }

            //Section 1.B - Finalized Calculations
            taxTotal = subTotal * TAXRATE;
            shippingCost = (qty * SHIPPING_PER_ANVIL);
            grandTotal = subTotal + taxTotal + shippingCost;

            //Section 2.A - Transactions
            WriteLine("{0,-22}{1,15}", "Quantity:", qty);
            WriteLine("{0,-22}{1,15:C}", "Cost per anvil:", anvilPrice);
            WriteLine("{0,-22}{1,15:C}", "Subtotal:", subTotalInitial);
            if (discount == true)  //Prints if user is part of Futility club
            {
                WriteLine("{0,-22}{1,15:C}", "Less 15% Futility Club:",
                    -discountTotal);
                WriteLine("{0,-22}{1,15:C}", "Taxable Amount:",
                    taxableAmount);
            }

            //Section 2.B - Transactions (Continued)
            WriteLine("{0,-22}{1,15:C}", "Sales Tax:", taxTotal);
            WriteLine("{0,-22}{1,15:C}", "Shipping:", shippingCost);
            WriteLine("\t_________");
            WriteLine("\n{0,-22}{1,15:C}", "TOTAL:", grandTotal);
            if (promotionPrize == true)
            {
                WriteLine("BONUS: Along with today's order, you'll " +
                    "receive a FREE {0}", freeItem);
            }
            WriteLine("*********************************");
            return grandTotal;
        }
        private static decimal GetAnvilPrice(int qty)
        {
            if (qty >= 1 && qty <= 9)
            {
                return 80.00m;
            }
            else if (qty >= 10 && qty <= 19)
            {
                return 72.35m;
            }
            else
            {
                return 67.99m;
            }
        }
    }
}