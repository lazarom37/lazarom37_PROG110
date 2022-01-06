using System;
using System.Collections.Generic;
using static System.Console;

namespace Ch99ListOfBandMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            string bandName;
            string person;
            string command;
            string memberOrMembers;
            //int memNum = 0;

            Write("What's the name of the band? ");
            bandName = ReadLine();

            //List<string> bandMembers = new List<string> { "John", "Paul" };
            List<string> bandMembers = new List<string>();

            Write("\n(A)dd a member, (R)emove a member, (D)isplay members or (Q)uit? ");
            command = ReadLine();

            do
            {
                switch (command.ToUpper())
                {

                    case "A":
                        Write($"Enter a member to add to {bandName}: ");
                        person = ReadLine();
                        bandMembers.Add(person);
                        //DisplayBandMembers(bandName, bandMembers);
                        break;
                    case "R":
                        Write($"Enter the name of the band member you want to remove from {bandName}: ");
                        person = ReadLine();
                        if (bandMembers.Remove(person))
                        {
                            WriteLine($"{person} successfully removed.");
                        }
                        else
                        {
                            WriteLine($"Sorry, {person} is not in the list.");
                        }

                        //DisplayBandMembers(bandName, bandMembers);

                        //Write($"Enter the number of the band member you want to remove (from 1 to {bandMembers.Count}): ");
                        //while (!int.TryParse(ReadLine(), out memNum))
                        //{
                        //    Write("Need an int, man.  Try again: ");
                        //}
                        //if (memNum > 0 && memNum <= bandMembers.Count)
                        //{
                        //    WriteLine($"{bandMembers[memNum - 1]} is history.");
                        //    bandMembers.RemoveAt(memNum - 1);
                        //}
                        //else
                        //{
                        //    Write("Invalid member number.  Try again: ");
                        //}
                        break;

                    case "D":
                        //DisplayBandMembers(bandName, bandMembers);
                        if (bandMembers.Count > 0)
                        {
                            memberOrMembers = bandMembers.Count == 1 ? "member" : "members";
                            WriteLine($"\n{bandName} has {bandMembers.Count} {memberOrMembers}:");
                            for (int i = 0; i < bandMembers.Count; i++)
                            {
                                WriteLine($"{i + 1}. {bandMembers[i]}");
                            }
                        }
                        else
                        {
                            WriteLine($"\n{bandName} has no members. ");
                        }
                        break;
                    default:
                        WriteLine("Invalid entry.  Please try again.");
                        break;
                }
                Write("\n(A)dd a member, (R)emove a member, (D)isplay members or (Q)uit? ");
                command = ReadLine();
            } while (command.ToUpper() != "Q");


            WriteLine("\nSee ya!");
            ReadKey();
        }

        //private static void DisplayBandMembers(string name, List<string> memberList)
        //{
        //    string memberOrMembers;

        //    if (memberList.Count > 0)
        //    {
        //        memberOrMembers = memberList.Count == 1 ? "member" : "members";
        //        WriteLine($"\n{name} has {memberList.Count}: {memberOrMembers}");
        //        for (int i = 0; i < memberList.Count; i++)
        //        {
        //            WriteLine($"{i + 1}. {memberList[i]}");
        //        }
        //    }
        //    else
        //    {
        //        WriteLine($"\n{name} has no members. ");
        //    }
        //}
    }
}
