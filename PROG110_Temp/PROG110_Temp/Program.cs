/********************************************************************* 
*    Course:     PROG 110 
*    Instructor: Marcus Lazaro
*    Term:       Fall 2021
*
*    Programmer: Marcus Lazaro
*    Assignment: XXXX
*    
*    Description: 
*    XXXXX
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
            string name;
            string desc;
            string id;
            string state;

            Write("Please enter a name: ");
            name = GetValidString(ReadLine(), 1);

            Write("Please enter a description: ");
            desc = GetValidString(ReadLine(), 1, 20);

            Write("Please enter Product ID: ");
            id = GetValidString(ReadLine(), 4, 5);

            Write("Please enter State Code: ");
            state = GetValidString(ReadLine(), 2, 2);

            Write($"Name: {name}");
            Write($"Description: {desc}");
            Write($"Product ID: {id}");
            Write($"State: {state}");
        }
        private static string GetValidString(string prompt, int min, int max)
        {
            while (prompt.Length < min || prompt.Length > max)
            {
                Write("Please re-enter: ");
                prompt = ReadLine();
            }
            return prompt;
        }
        private static string GetValidString(string prompt, int min)
        {
            while (prompt.Length < min)
            {
                Write("Please re-enter: ");
                prompt = ReadLine();
            }
            return prompt;
        }

    }
}